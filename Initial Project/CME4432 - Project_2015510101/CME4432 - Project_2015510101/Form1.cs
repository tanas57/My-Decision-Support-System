using System;
using System.Windows.Forms;
using weka;
namespace CME4432___Project_2015510101
{
    public partial class Form1 : Form
    {
        static weka.classifiers.Classifier cl = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void selectDataset_Click(object sender, EventArgs e)
        {
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
            if (path.Text.Length < 1)
            {
                info.Text = "select a dataset";
            }
            else if (selection.SelectedIndex == -1) info.Text = "select an algorithm";
            else
            {
                try
                {
                    string rs = "";
                    weka.core.Instances insts = new weka.core.Instances(new java.io.FileReader(path.Text));
                    insts.setClassIndex(insts.numAttributes() - 1);
                    switch (selection.SelectedIndex)
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
                    result.Items.Add(rs + " " + numCorrect + " out of " + insts.numInstances() + " correct (" +
                               (double)((double)numCorrect / (double)insts.numInstances() * 100.0) + "%)");



                }
                catch (Exception e2) { info.Text = e2.Message; }
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            result.Items.Clear();
            path.Text = ""; info.Text = "";
        }
    }
}
