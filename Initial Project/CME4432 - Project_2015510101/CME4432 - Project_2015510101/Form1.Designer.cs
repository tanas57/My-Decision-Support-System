namespace CME4432___Project_2015510101
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectDataset = new System.Windows.Forms.Button();
            this.process = new System.Windows.Forms.Button();
            this.selection = new System.Windows.Forms.ComboBox();
            this.path = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.ListBox();
            this.clear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // selectDataset
            // 
            this.selectDataset.Location = new System.Drawing.Point(12, 12);
            this.selectDataset.Name = "selectDataset";
            this.selectDataset.Size = new System.Drawing.Size(93, 44);
            this.selectDataset.TabIndex = 0;
            this.selectDataset.Text = "Select Dataset";
            this.selectDataset.UseVisualStyleBackColor = true;
            this.selectDataset.Click += new System.EventHandler(this.selectDataset_Click);
            // 
            // process
            // 
            this.process.Location = new System.Drawing.Point(188, 78);
            this.process.Name = "process";
            this.process.Size = new System.Drawing.Size(96, 31);
            this.process.TabIndex = 1;
            this.process.Text = "process";
            this.process.UseVisualStyleBackColor = true;
            this.process.Click += new System.EventHandler(this.process_Click);
            // 
            // selection
            // 
            this.selection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selection.FormattingEnabled = true;
            this.selection.Items.AddRange(new object[] {
            "Naïve Bayes algorithm",
            "K-Nearest Neighbour algorithm",
            "Decision Tree algorithm ",
            "Artificial Neural Network algorithm",
            "Support Vector Machine algorithm "});
            this.selection.Location = new System.Drawing.Point(12, 82);
            this.selection.Name = "selection";
            this.selection.Size = new System.Drawing.Size(157, 24);
            this.selection.TabIndex = 2;
            // 
            // path
            // 
            this.path.AutoSize = true;
            this.path.Location = new System.Drawing.Point(121, 26);
            this.path.Name = "path";
            this.path.Size = new System.Drawing.Size(0, 17);
            this.path.TabIndex = 3;
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.ForeColor = System.Drawing.Color.Red;
            this.info.Location = new System.Drawing.Point(291, 86);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 17);
            this.info.TabIndex = 4;
            // 
            // result
            // 
            this.result.FormattingEnabled = true;
            this.result.ItemHeight = 16;
            this.result.Location = new System.Drawing.Point(12, 112);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(864, 292);
            this.result.TabIndex = 5;
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(780, 75);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(96, 31);
            this.clear.TabIndex = 6;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 413);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.result);
            this.Controls.Add(this.info);
            this.Controls.Add(this.path);
            this.Controls.Add(this.selection);
            this.Controls.Add(this.process);
            this.Controls.Add(this.selectDataset);
            this.Name = "Form1";
            this.Text = "Main Form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectDataset;
        private System.Windows.Forms.Button process;
        private System.Windows.Forms.ComboBox selection;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.ListBox result;
        private System.Windows.Forms.Button clear;
    }
}

