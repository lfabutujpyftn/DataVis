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
    public partial class Open : Form
    {
        private Form main;
        private string dir;
        public Open(Form f)
        {
            InitializeComponent();
            main = f;
            main.Enabled = false;
            dir = "";
            textBox1.Enabled = false;
            textBox1.Text = "Open directory";
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (dir != "")
            {
                var mainForm = new MainForm(main, dir);
                mainForm.Show();
                this.Close();
            }
        }

        private void buttonDir_Click(object sender, EventArgs e)
        {
            DialogResult res = folderBrowserDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                dir = folderBrowserDialog.SelectedPath.Replace("\\", "/");
                textBox1.Text = dir;
            }
        }
        private void Open_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            main.Enabled = true;
        }
    }
}
