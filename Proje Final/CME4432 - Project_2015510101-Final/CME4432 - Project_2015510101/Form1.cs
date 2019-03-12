using System;
using System.Windows.Forms;
using weka;
namespace CME4432___Project_2015510101
{
    public partial class Form1 : Form
    {
        static weka.classifiers.Classifier cl = null; static int numOfAttributes = 0;
        static weka.core.Instances insts = null;
        Label[] lbls; ComboBox[] nominals; TextBox[] numerics; bool [] attType;
        int selectedAlgorithm; double selectedAlgoScore;
        string[] algorithms = { "Naïve Bayes", "K-Nearest Neighbour", "Decision Tree", "Artificial Neural Network", "Support Vector Machine" };
        string[] classes;
        public Form1()
        {
            InitializeComponent();
        }

        private void selectDataset_Click(object sender, EventArgs e)
        {
            clearControls();
            OpenFileDialog file = new OpenFileDialog();
            file.Multiselect = false;
            file.Title = "Select a dataset";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path.Text = file.FileName;
                string DosyaAdi = file.SafeFileName;
            }
        }

        private void process_Click(object sender, EventArgs e)
        {
            try
            {
                if (path.Text.Length < 1)
                {
                    info.Text = "select a dataset";
                }
                else
                {
                    this.Text = "Processing please wait...";
                    double control = 0.0;
                    for (int algo = 0; algo < 5; algo++)
                    {
                        string rs = "";
                        insts = new weka.core.Instances(new java.io.FileReader(path.Text));
                        insts.setClassIndex(insts.numAttributes() - 1);

                        classes = insts.classAttribute().toString().Split('{')[1].Split('}')[0].Split(',');
                        

                        numOfAttributes = insts.numAttributes() - 1;
                        switch (algo)
                        {
                            case 0: // Naïve Bayes algorithm
                                rs += "Naïve Bayes : ";
                                cl = new weka.classifiers.bayes.NaiveBayes();

                                // nominal to numeric
                                weka.filters.Filter numericdata = new weka.filters.unsupervised.attribute.NominalToBinary();
                                numericdata.setInputFormat(insts);
                                insts = weka.filters.Filter.useFilter(insts, numericdata);

                                break;

                            case 1: // K-Nearest Neighbour algorithm
                                rs += "K-Nearest : ";
                                cl = new weka.classifiers.lazy.IBk();

                                // nominal to numeric
                                weka.filters.Filter disData = new weka.filters.unsupervised.attribute.Discretize();
                                disData.setInputFormat(insts);
                                insts = weka.filters.Filter.useFilter(insts, disData);

                                break;

                            case 2: //  Decision Tree algorithm 
                                rs += "Decision Tree : ";
                                cl = new weka.classifiers.trees.J48();
                                break;
                            case 3:
                                rs += "Artificial Neural Network : ";
                                cl = new weka.classifiers.functions.MultilayerPerceptron();
                                // nominal to numeric
                                weka.filters.Filter numericdata2 = new weka.filters.unsupervised.attribute.NominalToBinary();
                                numericdata2.setInputFormat(insts);
                                insts = weka.filters.Filter.useFilter(insts, numericdata2);

                                break; // Artificial Neural Network algorithm
                            case 4:
                                rs += "Support Vector Machine : ";
                                cl = new weka.classifiers.functions.SMO();

                                // nominal to numeric
                                weka.filters.Filter numericdata3 = new weka.filters.unsupervised.attribute.NominalToBinary();
                                numericdata3.setInputFormat(insts);
                                insts = weka.filters.Filter.useFilter(insts, numericdata3);

                                break; // Support Vector Machine algorithm

                        }

                        // normalize data
                        weka.filters.Filter myNormalized = new weka.filters.unsupervised.instance.Normalize();
                        myNormalized.setInputFormat(insts);
                        insts = weka.filters.Filter.useFilter(insts, myNormalized);

                        weka.core.Instances train = new weka.core.Instances(insts, 0, insts.numInstances());

                        cl.buildClassifier(train);

                        string str = cl.toString();

                        int numCorrect = 0;
                        for (int i = 0; i < insts.numInstances(); i++)
                        {
                            weka.core.Instance currentInst = insts.instance(i);
                            double predictedClass = cl.classifyInstance(currentInst);
                            if (predictedClass == insts.instance(i).classValue())
                                numCorrect++;
                        }
                        double score = (double)((double)numCorrect / (double)insts.numInstances() * 100.0);
                        if(control < score)
                        {
                            control = score;
                            selectedAlgorithm = algo;
                            selectedAlgoScore = score;
                        }
                    }
                    this.Text = "Give me your inputs";
                    info.Text = "the best algoritm is " + algorithms[selectedAlgorithm] + " " + selectedAlgoScore + " %";

                    insts = new weka.core.Instances(new java.io.FileReader(path.Text));
                    insts.setClassIndex(insts.numAttributes() - 1);

                    numOfAttributes = insts.numAttributes() - 1;

                    int startx = 20, starty = 120, addTop = 25, addLeft = 100;
                    int texts = 0, combo = 0, cr1 = 0, cr2 = 0;
                    lbls = new Label[insts.numAttributes()];

                    for (int i = 0; i < numOfAttributes; i++)
                    {
                        if (insts.attribute(i).isNominal()) combo++;
                        else if (insts.attribute(i).isNumeric()) texts++;
                    }

                    numerics = new TextBox[texts];
                    nominals = new ComboBox[combo];
                    attType = new bool[numOfAttributes];

                    this.Height += (numOfAttributes+1) * addTop;
                    research.Visible = true;
                    for (int i = 0; i < numOfAttributes; i++)
                    {
                        if (insts.attribute(i).isNominal())
                        {
                            string[] param1 = insts.attribute(i).toString().Split('{');
                            string[] param2 = param1[1].Split('}');
                            string[] param3 = param2[0].Split(',');

                            nominals[cr1] = new ComboBox();
                            lbls[i] = new Label();
                            for (int a = 0; a < param3.Length; a++) nominals[cr1].Items.Add(param3[a].Replace('\'', ' ').Trim());

                            lbls[i].Text = insts.attribute(i).name();
                            lbls[i].Left = startx; lbls[i].Top = starty;
                            nominals[cr1].Left = startx + addLeft; nominals[cr1].Top = starty; nominals[cr1].DropDownStyle = ComboBoxStyle.DropDownList;
                            starty += addTop;
                            Controls.Add(nominals[cr1]); Controls.Add(lbls[i]);
                            cr1++;
                            attType[i] = true;
                        }
                        else if (insts.attribute(i).isNumeric())
                        {
                            numerics[cr2] = new TextBox();
                            lbls[i] = new Label();
                            lbls[i].Text = insts.attribute(i).name();
                            lbls[i].Left = startx; lbls[i].Top = starty;

                            numerics[cr2].Left = startx + addLeft; numerics[cr2].Top = starty;
                            starty += addTop;
                            Controls.Add(numerics[cr2]); Controls.Add(lbls[i]);
                            cr2++;
                            attType[i] = false;
                        }

                    }

                }
            }
            catch (Exception e2) { info.Text = e2.Message; }
        }
        
        private void clear_Click(object sender, EventArgs e)
        {
            clearControls();
        }
        
        private void clearControls()
        {
            path.Text = ""; info.Text = "";
            this.Text = "Welcome my Decision Maker Program. Select a dataset";
            lbls = null; nominals = null; numerics = null; cl = null;
            research.Visible = false; showResult.Visible = false;
            this.Height = 150;
            if (nominals != null && lbls != null && numerics != null)
            {
                for (int i = 0; i < nominals.Length; i++) Controls.Remove(nominals[i]);
                for (int i = 0; i < lbls.Length; i++) Controls.Remove(lbls[i]);
                for (int i = 0; i < numerics.Length; i++) Controls.Remove(numerics[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            for(int i = 0; i < nominals.Length; i++)
            {
                if (nominals[i].SelectedIndex == -1) { flag = true; }
            }
            if (!flag)
            {
                insts = new weka.core.Instances(new java.io.FileReader(path.Text));
                insts.setClassIndex(insts.numAttributes() - 1);

                switch (selectedAlgorithm)
                {
                    case 0: // Naïve Bayes algorithm
                        cl = new weka.classifiers.bayes.NaiveBayes();

                        // nominal to numeric
                        weka.filters.Filter numericdata = new weka.filters.unsupervised.attribute.NominalToBinary();
                        numericdata.setInputFormat(insts);
                        insts = weka.filters.Filter.useFilter(insts, numericdata);

                        break;

                    case 1: // K-Nearest Neighbour algorithm
                        cl = new weka.classifiers.lazy.IBk();

                        // nominal to numeric
                        weka.filters.Filter disData = new weka.filters.unsupervised.attribute.Discretize();
                        disData.setInputFormat(insts);
                        insts = weka.filters.Filter.useFilter(insts, disData);

                        break;

                    case 2: //  Decision Tree algorithm 
                        cl = new weka.classifiers.trees.J48();
                        break;
                    case 3:
                        cl = new weka.classifiers.functions.MultilayerPerceptron();
                        // nominal to numeric
                        weka.filters.Filter numericdata2 = new weka.filters.unsupervised.attribute.NominalToBinary();
                        numericdata2.setInputFormat(insts);
                        insts = weka.filters.Filter.useFilter(insts, numericdata2);

                        break; // Artificial Neural Network algorithm
                    case 4:
                        cl = new weka.classifiers.functions.SMO();

                        // nominal to numeric
                        weka.filters.Filter numericdata3 = new weka.filters.unsupervised.attribute.NominalToBinary();
                        numericdata3.setInputFormat(insts);
                        insts = weka.filters.Filter.useFilter(insts, numericdata3);

                        break; // Support Vector Machine algorithm

                }

                // normalize data
                weka.filters.Filter myNormalized = new weka.filters.unsupervised.instance.Normalize();
                myNormalized.setInputFormat(insts);
                insts = weka.filters.Filter.useFilter(insts, myNormalized);

                weka.core.Instances train = new weka.core.Instances(insts, 0, insts.numInstances());

                cl.buildClassifier(train);

                weka.core.Instance newIns = new weka.core.Instance(numOfAttributes);
                newIns.setDataset(insts);
                int c1 = 0, c2 = 0;
                for (int i = 0; i < numOfAttributes; i++)
                {
                    if (attType[i]) // nominal
                    {
                        newIns.setValue(i, nominals[c1].SelectedItem.ToString());
                        c1++;
                    }
                    else // numeric
                    {
                        newIns.setValue(i, double.Parse(numerics[c2].Text));
                        c2++;
                    }
                    
                }
                double result2 = cl.classifyInstance(newIns);
                showResult.Visible = true;
                showResult.Text = classes[(int)result2].Replace('\'', ' ').Trim();
                this.Text = "here, program results is ==>> " + showResult.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Welcome my Decision Maker Program. Select a dataset";
        }
    }
}
