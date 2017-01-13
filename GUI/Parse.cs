using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using System.IO;

namespace GUI
{
    public partial class Parse : Form
    {
        //private Form main;
        private MainForm mainform;
        private string d;
        private string f;
        private string o;
        private string dir;
        bool parse;
        public Parse(MainForm f)
        {
            InitializeComponent();
            mainform = f;
            mainform.Enabled = false;
            //main = f;
            //main.Enabled = false;
            d = "";
            o = "";
            dir = "";
            this.f = "";
            this.parse = false;
            
        }

        private void Parse_Load(object sender, EventArgs e)
        {
            textBoxD.Enabled = false;
            textBoxF.Enabled = false;
            textBoxO.Enabled = false;
            textBoxDir.Enabled = false;
            textBoxD.Text = "D_GRG";
            textBoxF.Text = "F_GRG";
            textBoxO.Text = "O_GRG";
            textBoxDir.Text = "Save directory";
            progressBar.Maximum = 100;
            textBox1.Enabled = false;
            textBox1.Text = "";
            if (File.Exists("./Setting/ParseFormPath.tun"))
            {
                FileStream file = new FileStream("./Setting/ParseFormPath.tun", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                string tmp = reader.ReadLine();
                d = tmp;
                textBoxD.Text = tmp; 
                tmp = reader.ReadLine();
                f = tmp;
                textBoxF.Text = tmp;
                tmp = reader.ReadLine();
                o = tmp;
                textBoxO.Text = tmp;
                tmp = reader.ReadLine();
                dir = tmp;
                textBoxDir.Text = tmp;
                reader.Close();
                file.Close();
            }
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
            if (d != "" && f != "" && dir != "" && o != "")
            {
                string err = "";
                if (!File.Exists(d))
                {
                    err += d + " ";
                }
                if (!File.Exists(f))
                {
                    err += f + " ";
                }
                if (!File.Exists(o))
                {
                    err += o + " ";
                }
                if (!Directory.Exists(dir))
                {
                    err += dir + " ";
                }
                if (err != "")
                {
                    MessageBox.Show("File " + err + " not exists");
                    return;
                }
                if(parse == false)
                {
                    buttonD.Enabled = false;
                    buttonF.Enabled = false;
                    buttonO.Enabled = false;
                    buttonDir.Enabled = false;
                    buttonParse.Enabled = false;
                    Thread th = new Thread(func);
                    //mainform.init(d, f, o, dir);
                    //mainform.controller.savePathParseDir(d, f, o, dir);
                   // mainform = new MainForm(main, d, f, dir);
                    //Task tsk = new Task(func);
                    //func();
                    th.Start();
                    //await tsk.Run();
                    //mainform.Show();

                    //mainform.Show();
                    //this.Close();
                }
                else
                {
                    //mainform.Show();
                    mainform.initFin();
                    mainform.Enabled = true;
                    this.Close();
                }

            }
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
        private void Open_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainform.Enabled = true;
        }

        private void func()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            textBox1.Text = "Cleaning directory";
            if (Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }
            progressBar.Value += 100 / 4;
            mainform.init(d, f, o, dir);
            mainform.controller.savePathParseDir(d, f, o, dir);
            textBox1.Text = "Parse const t diagram data";
            mainform.controller.ParseCT();
            progressBar.Value += 100 / 4;
            textBox1.Text = "Parse along ID and XT diagram data";
            mainform.controller.ParseAID_XT();
            progressBar.Value += 100 / 4;
            textBox1.Text = "Parse 3d diagram data";
            mainform.controller.Parse3d();
            progressBar.Value += 100 / 4;
            buttonParse.Text = "Start";
            this.parse = true;
            buttonParse.Enabled = true;
            textBox1.Text = "OK";
            progressBar.Value = 0;
        }

        private void buttonO_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                o = openFileDialog.FileName;
                textBoxO.Text = o;
            }
        }

    }
}
