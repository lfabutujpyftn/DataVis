namespace GUI
{
    partial class Parse
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
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.textBoxF = new System.Windows.Forms.TextBox();
            this.buttonD = new System.Windows.Forms.Button();
            this.buttonF = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonParse = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.buttonDir = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(12, 12);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size(345, 20);
            this.textBoxD.TabIndex = 0;
            // 
            // textBoxF
            // 
            this.textBoxF.Location = new System.Drawing.Point(12, 38);
            this.textBoxF.Name = "textBoxF";
            this.textBoxF.Size = new System.Drawing.Size(345, 20);
            this.textBoxF.TabIndex = 1;
            // 
            // buttonD
            // 
            this.buttonD.Location = new System.Drawing.Point(363, 9);
            this.buttonD.Name = "buttonD";
            this.buttonD.Size = new System.Drawing.Size(75, 23);
            this.buttonD.TabIndex = 2;
            this.buttonD.Text = "Choose";
            this.buttonD.UseVisualStyleBackColor = true;
            this.buttonD.Click += new System.EventHandler(this.buttonD_Click);
            // 
            // buttonF
            // 
            this.buttonF.Location = new System.Drawing.Point(364, 35);
            this.buttonF.Name = "buttonF";
            this.buttonF.Size = new System.Drawing.Size(75, 23);
            this.buttonF.TabIndex = 3;
            this.buttonF.Text = "Choose";
            this.buttonF.UseVisualStyleBackColor = true;
            this.buttonF.Click += new System.EventHandler(this.buttonF_Click);
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(364, 90);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(75, 23);
            this.buttonParse.TabIndex = 4;
            this.buttonParse.Text = "Parse";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.buttonParse_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // textBoxDir
            // 
            this.textBoxDir.Location = new System.Drawing.Point(12, 64);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(345, 20);
            this.textBoxDir.TabIndex = 5;
            // 
            // buttonDir
            // 
            this.buttonDir.Location = new System.Drawing.Point(363, 61);
            this.buttonDir.Name = "buttonDir";
            this.buttonDir.Size = new System.Drawing.Size(75, 23);
            this.buttonDir.TabIndex = 6;
            this.buttonDir.Text = "Choose";
            this.buttonDir.UseVisualStyleBackColor = true;
            this.buttonDir.Click += new System.EventHandler(this.buttonDir_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 90);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(345, 23);
            this.progressBar.TabIndex = 7;
            // 
            // Parse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 123);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonDir);
            this.Controls.Add(this.textBoxDir);
            this.Controls.Add(this.buttonParse);
            this.Controls.Add(this.buttonF);
            this.Controls.Add(this.buttonD);
            this.Controls.Add(this.textBoxF);
            this.Controls.Add(this.textBoxD);
            this.MaximumSize = new System.Drawing.Size(464, 162);
            this.MinimumSize = new System.Drawing.Size(464, 162);
            this.Name = "Parse";
            this.Text = "Parse";
            this.Load += new System.EventHandler(this.Parse_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Parse_Closing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxD;
        private System.Windows.Forms.TextBox textBoxF;
        private System.Windows.Forms.Button buttonD;
        private System.Windows.Forms.Button buttonF;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Button buttonDir;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}