﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GUI
{
    public partial class Open : Form
    {
        private MainForm main;
        private string dir;
        public Open(MainForm f)
        {
            InitializeComponent();
            main = f;
            main.Enabled = false;
            dir = "";
            textBox1.Enabled = false;
            textBox1.Text = "Open directory";
            if(File.Exists("./Setting/OpenFormPath.tun"))
            {
                FileStream file = new FileStream("./Setting/OpenFormPath.tun", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                string tmp = reader.ReadLine();
                dir = tmp;
                textBox1.Text = tmp;
                reader.Close();
                file.Close();
            }
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (dir != "")
            {
                if (!Directory.Exists(dir))
                {
                    MessageBox.Show("Directory " + dir + " not exists");
                    return;
                }
                main.init(dir);
                main.Enabled = true;
                main.controller.savePathLoadDir(dir);
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
