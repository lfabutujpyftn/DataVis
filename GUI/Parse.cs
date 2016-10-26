using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Parse : Form
    {
        private Form main;
        private string d;
        private string f;
        private string dir;
        public Parse(Form f)
        {
            InitializeComponent();
            main = f;
            main.Enabled = false;
            d = "";
            dir = "";
            this.f = "";
        }

        private void Parse_Load(object sender, EventArgs e)
        {
            textBoxD.Enabled = false;
            textBoxF.Enabled = false;
            textBoxDir.Enabled = false;
            textBoxD.Text = "D_GRG";
            textBoxF.Text = "F_GRG";
            textBoxDir.Text = "Save directory";
            progressBar.Maximum = 100;
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            DialogResult res =  openFileDialog.ShowDialog();
            if(res == System.Windows.Forms.DialogResult.OK)
            {
                d = openFileDialog.FileName;
                textBoxD.Text = d;
            }
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                f = openFileDialog.FileName;
                textBoxF.Text = f;
            }
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            if (d != "" && f != "" && dir != "")
            {
                var mainForm = new MainForm(main, d, f, dir);
                mainForm.controller.ParseCT();
                progressBar.Value += 100 / 4;
                mainForm.controller.ParseAID_XT();
                progressBar.Value += 100 / 4;
                //mainForm.controller.ParseXT();
                progressBar.Value += 100 / 4;
                mainForm.controller.ParseCX();
                progressBar.Value += 100 / 4;
                mainForm.Show();
                this.Close();
            }
        }
        private void Parse_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            main.Enabled = true;
        }
        private void buttonDir_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                dir = folderBrowserDialog.SelectedPath.Replace("\\","/");
                textBoxDir.Text = dir;
            }
        }
    }
}
