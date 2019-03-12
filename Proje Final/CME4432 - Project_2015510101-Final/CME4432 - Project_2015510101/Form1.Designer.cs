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
            this.path = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.research = new System.Windows.Forms.Button();
            this.showResult = new System.Windows.Forms.Label();
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
            this.process.Location = new System.Drawing.Point(12, 79);
            this.process.Name = "process";
            this.process.Size = new System.Drawing.Size(96, 47);
            this.process.TabIndex = 1;
            this.process.Text = "check algorithms";
            this.process.UseVisualStyleBackColor = true;
            this.process.Click += new System.EventHandler(this.process_Click);
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
            this.info.ForeColor = System.Drawing.Color.Black;
            this.info.Location = new System.Drawing.Point(230, 94);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 17);
            this.info.TabIndex = 4;
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(114, 79);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(103, 47);
            this.clear.TabIndex = 6;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // research
            // 
            this.research.Location = new System.Drawing.Point(377, 118);
            this.research.Name = "research";
            this.research.Size = new System.Drawing.Size(144, 85);
            this.research.TabIndex = 7;
            this.research.Text = "Explore";
            this.research.UseVisualStyleBackColor = true;
            this.research.Visible = false;
            this.research.Click += new System.EventHandler(this.button1_Click);
            // 
            // showResult
            // 
            this.showResult.AutoSize = true;
            this.showResult.Font = new System.Drawing.Font("Leelawadee UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showResult.Location = new System.Drawing.Point(415, 215);
            this.showResult.Name = "showResult";
            this.showResult.Size = new System.Drawing.Size(74, 32);
            this.showResult.TabIndex = 8;
            this.showResult.Text = "result";
            this.showResult.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 256);
            this.Controls.Add(this.showResult);
            this.Controls.Add(this.research);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.info);
            this.Controls.Add(this.path);
            this.Controls.Add(this.process);
            this.Controls.Add(this.selectDataset);
            this.Name = "Form1";
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectDataset;
        private System.Windows.Forms.Button process;
        private System.Windows.Forms.Label path;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button clear;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button research;
        private System.Windows.Forms.Label showResult;
    }
}

