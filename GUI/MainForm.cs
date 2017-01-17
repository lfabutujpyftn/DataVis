using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parser;
using Plot;
using Controller;
using Tuner;
using System.IO;
using System.Collections;

namespace GUI
{
    
    public partial class MainForm : Form
    {
        public CController controller;
        //private Form main;
        public string dir;
        public string dgrg;
        public string fgrg;
        public string ogrg;
        public string pathToGNP;
        bool legend;
        bool autoscale;
        public bool xrange;
        public double xfrom;
        public double xto;
        public bool yrange;
        public double yfrom;
        public double yto;
        int findIndex;

        public MainForm()
        {
            InitializeComponent();
            legend = false;
            autoscale = true;
            xrange = false;
            xfrom = 0;
            xto = 1;
            yrange = false;
            yfrom = 0;
            yto = 1;
            findIndex = -1;
            //findIndex = 0;
            selectToolStripMenuItem.Enabled = false;
            sortingToolStripMenuItem.Enabled = false;
            styleToolStripMenuItem.Enabled = false;
            pathToGNP = "C:/Program Files/gnuplot/bin/gnuplot.exe";
            tabControl.Enabled = false;
            settingToolStripMenuItem.Enabled = false;
            videlitToolStripMenuItem.Enabled = false;
            if (!Directory.Exists("./Setting"))
            {
                Directory.CreateDirectory("./Setting");
            } 
            if (File.Exists("./Setting/gnuplot.tun"))
            {
                FileStream file = new FileStream("./Setting/gnuplot.tun", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(file);
                pathToGNP = reader.ReadLine();
                toolStripMenuItem2.Text = pathToGNP;
                file.Close();
            }
            else 
            {
                fileToolStripMenuItem.Enabled = false;
                settingToolStripMenuItem.Enabled = true;
                legendToolStripMenuItem.Enabled = false;
                rangeToolStripMenuItem.Enabled = false;
            }
        }

        public void init(string dir)
        {
            controller = new CController(dir, pathToGNP);
            this.dir = dir;
            initData(); 
            tabControl.Enabled = true;
            settingToolStripMenuItem.Enabled = true;
            videlitToolStripMenuItem.Enabled = true;

        }
        public void init(string dgrg, string fgrg, string ogrg, string dir)
        {
            controller = new CController(dgrg, fgrg, ogrg, dir,pathToGNP);
            this.dir = dir;
            this.dgrg = dgrg;
            this.fgrg = fgrg;
            this.ogrg = ogrg;
        }

        public void initFin()
        {
            initData();
            tabControl.Enabled = true;
            settingToolStripMenuItem.Enabled = true;
            videlitToolStripMenuItem.Enabled = true;
        }

        public void initData()
        {
            checkedListBoxAlongId.Items.Clear();
            checkedListBoxColAlongId.Items.Clear();
            checkedListBoxColoms.Items.Clear();
            checkedListBoxTime.Items.Clear();
            checkedListBoxXT.Items.Clear();
            
            foreach(DataNode s in controller.getColums())
            {
                if(s.reduction != "X")
                    if (s.measure != "служебный")
                    {
                        checkedListBoxColoms.Items.Add(s.reduction + " " + s.name);
                        checkedListBoxColAlongId.Items.Add(s.reduction + " " + s.name);
                        comboBox3D.Items.Add(s.reduction + " " + s.name);
                        //checkedListBoxCX.Items.Add(s.reduction + " " + s.name);
                    }
            }
            comboBox3D.SelectedItem = comboBox3D.Items[0];
            FileStream fileT = new FileStream(dir + "/ConstT/time", FileMode.Open, FileAccess.Read);
            StreamReader readerT = new StreamReader(fileT);
            while (!readerT.EndOfStream)
            {
                checkedListBoxTime.Items.Add(readerT.ReadLine());
            }
            readerT.Close();
            fileT.Close();

            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach(DataNodeLine i in controller.getLineType())
            {
                dict.Add(i.reduction, i.name);
            }
            string g = "";
            foreach(var i in dict)
            {
                g += i.Key + " ";
            }
            //MessageBox.Show(g);
            FileStream fileID = new FileStream(dir + "/AlongID_XT/ID", FileMode.Open, FileAccess.Read);
            StreamReader readerID = new StreamReader(fileID);
            while (!readerID.EndOfStream)
            {
                string str = readerID.ReadLine();
                string[] tmp = str.Split(new char[] { ' ' });
                var arr = new ArrayList();
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        arr.Add(s);
                    }
                }
                //MessageBox.Show(arr[1].ToString());
                string res = arr[0].ToString() + " " + dict[arr[1].ToString()];
                checkedListBoxAlongId.Items.Add(res);
                checkedListBoxXT.Items.Add(res);
            }
            readerID.Close();
            fileID.Close();
            
                for (int i = 0; i < checkedListBoxAlongId.Items.Count; ++i)
                {
                    checkedListBoxAlongId.SetItemChecked(i, true);
                }
                for (int i = 0; i < checkedListBoxXT.Items.Count; ++i)
                {
                    checkedListBoxXT.SetItemChecked(i, true);
                }
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        

        private void buttonPlotCT_Click(object sender, EventArgs e)
        {
            if (checkedListBoxTime.CheckedItems.Count == 0 && checkedListBoxColoms.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select time and paremetrs");
            }
            else if(checkedListBoxColoms.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select paremetrs");
            }
            else if (checkedListBoxTime.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select time");
            }
            if(checkedListBoxColoms.CheckedItems.Count != 0 && checkedListBoxTime.CheckedItems.Count != 0)
            {
              //  FileStream fileT = new FileStream(dir + "/tmp.tmp", FileMode.Create, FileAccess.Write);
              //  StreamWriter wT = new StreamWriter(fileT);
                ArrayList time = new ArrayList();
                ArrayList coloms = new ArrayList();
                foreach (string s in checkedListBoxTime.CheckedItems)
                {
                    string[] tmp = s.Split(new char[] { ' ' });
                    int i = 0;
                    string t = "";
                    foreach (string s2 in tmp)
                    {
                        if (s2.Trim() != "")
                        {
                            if (i == 0)
                            {
                                t = s2;
                                break;
                            }
                            ++i;
                        }
                    }
             //       wT.WriteLine(t);
                    time.Add(t);
                }
                foreach (string s in checkedListBoxColoms.CheckedItems)
                {
             //       wT.WriteLine(s);
                    coloms.Add(s);
                }
            //    wT.Close();
            //    fileT.Close();
                Thread thread = new Thread(this.pltct);
                thread.Start(new Data(time, coloms));
               // controller.PlotSelectItemConstT(time, coloms);
            }
        }

        private void pltct(object data)
        {
            this.buttonPlotCT.Enabled = false;
            Data tmp = (Data)data;
            controller.PlotSelectItemConstT(tmp.d1, tmp.d2);
            Thread.Sleep(3000);
            this.buttonPlotCT.Enabled = true;
        }

        private void pltaid(object data)
        {
            this.buttonPlotAlongId.Enabled = false;
            Data tmp = (Data)data;
            controller.PlotSelectItemAlongID(tmp.d1, tmp.d2);
            Thread.Sleep(3000);
            this.buttonPlotAlongId.Enabled = true;
        }

        private void pltxt(object data)
        {
            this.buttonPlotXt.Enabled = false;
            Data tmp = (Data)data;
            controller.PlotSelectItemXT(tmp.d1);
            Thread.Sleep(3000);
            this.buttonPlotXt.Enabled = true;
        }

        private void buttonPlotAlongId_Click(object sender, EventArgs e)
        {
            if (checkedListBoxAlongId.CheckedItems.Count == 0 && checkedListBoxColAlongId.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select idline and paremetrs");
            }
            else if (checkedListBoxColAlongId.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select paremetrs");
            }
            else if (checkedListBoxAlongId.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select idline");
            }
            if (checkedListBoxAlongId.CheckedItems.Count != 0 && checkedListBoxColAlongId.CheckedItems.Count != 0)
            {
                //FileStream fileID = new FileStream(dir + "/tmp.tmp", FileMode.Create, FileAccess.Write);
                //StreamWriter wID = new StreamWriter(fileID);
                ArrayList ID = new ArrayList();
                ArrayList coloms = new ArrayList();
                foreach (string s in checkedListBoxAlongId.CheckedItems)
                {
              //      wID.WriteLine(s);
                    ID.Add(s);
                }
               // string col = "";
                foreach (string s in checkedListBoxColAlongId.CheckedItems)
                {
              //      wID.WriteLine(s);
                    coloms.Add(s);
                //    col += s;
                }
               // MessageBox.Show(col);
             //   wID.Close();
                //   fileID.Close();
                Thread thread = new Thread(this.pltaid);
                thread.Start(new Data(ID, coloms));
                //controller.PlotSelectItemAlongID(ID, coloms);
            }
        }

        private void buttonPlotXt_Click(object sender, EventArgs e)
        {
            if (checkedListBoxXT.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select idline");
            }
            if (checkedListBoxXT.CheckedItems.Count != 0)
            {
                //FileStream fileID = new FileStream(dir + "/tmp.tmp", FileMode.Create, FileAccess.Write);
                //StreamWriter wID = new StreamWriter(fileID);
                ArrayList ID = new ArrayList();
                //ArrayList coloms = new ArrayList();
                foreach (string s in checkedListBoxXT.CheckedItems)
                {
                   // wID.WriteLine(s);
                    ID.Add(s);
                }
               // wID.Close();
               // fileID.Close();
                //     MessageBox.Show("Formexec");
                Thread thread = new Thread(this.pltxt);
                thread.Start(new Data(ID, new ArrayList()));
                //controller.PlotSelectItemXT(ID);
            }
        }

        private void legendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(legendToolStripMenuItem.Checked)
            {
                legendToolStripMenuItem.Checked = false;
                legend = false;

            }
            else
            {
                legend = true;
                legendToolStripMenuItem.Checked = true;
            }
            controller.Legend = legend;
        }

        private void videlitallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tabControl.SelectedIndex == 0)
            {
                for (int i = 0; i < checkedListBoxTime.Items.Count; ++i )
                {
                    checkedListBoxTime.SetItemChecked(i, true);
                }
            }
            if (tabControl.SelectedIndex == 1)
            {
                for (int i = 0; i < checkedListBoxAlongId.Items.Count; ++i)
                {
                    checkedListBoxAlongId.SetItemChecked(i, true);
                }
            }
            if (tabControl.SelectedIndex == 2)
            {
                for (int i = 0; i < checkedListBoxXT.Items.Count; ++i)
                {
                    checkedListBoxXT.SetItemChecked(i, true);
                }
            }
        }

        private void ochistitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                for (int i = 0; i < checkedListBoxTime.Items.Count; ++i)
                {
                    checkedListBoxTime.SetItemChecked(i, false);
                }
            }
            if (tabControl.SelectedIndex == 1)
            {
                for (int i = 0; i < checkedListBoxAlongId.Items.Count; ++i)
                {
                    checkedListBoxAlongId.SetItemChecked(i, false);
                }
            }
            if (tabControl.SelectedIndex == 2)
            {
                for (int i = 0; i < checkedListBoxXT.Items.Count; ++i)
                {
                    checkedListBoxXT.SetItemChecked(i, false);
                }
            }
        }

        private void iDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lineTypeToolStripMenuItem.Checked == true)
            {
                lineTypeToolStripMenuItem.Checked = false;
                iDToolStripMenuItem.Checked = true;
                Dictionary<string, bool> dictalid = new Dictionary<string, bool>();
                Dictionary<string, bool> dictxt = new Dictionary<string, bool>();
                for (int i = 0; i < checkedListBoxAlongId.Items.Count; ++i)
                {
                    dictalid.Add((string)checkedListBoxAlongId.Items[i], checkedListBoxAlongId.GetItemChecked(i));
                }
                for (int i = 0; i < checkedListBoxXT.Items.Count; ++i)
                {
                    dictxt.Add((string)checkedListBoxXT.Items[i], checkedListBoxXT.GetItemChecked(i));
                }
                checkedListBoxAlongId.Items.Clear();
                checkedListBoxXT.Items.Clear();
                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (DataNodeLine i in controller.getLineType())
                {
                    dict.Add(i.reduction, i.name);
                }

                FileStream fileID = new FileStream(dir + "/AlongID_XT/ID", FileMode.Open, FileAccess.Read);
                StreamReader readerID = new StreamReader(fileID);
                while (!readerID.EndOfStream)
                {
                    string str = readerID.ReadLine();
                    string[] tmp = str.Split(new char[] { ' ' });
                    var arr = new ArrayList();
                    foreach (string s in tmp)
                    {
                        if (s.Trim() != "")
                        {
                            arr.Add(s);
                        }
                    }
                    string res = arr[0].ToString() + " " + dict[arr[1].ToString()];
                    checkedListBoxAlongId.Items.Add(res);
                    checkedListBoxXT.Items.Add(res);
                    checkedListBoxXT.SetItemChecked(checkedListBoxXT.Items.Count - 1, dictxt[res]);
                    checkedListBoxAlongId.SetItemChecked(checkedListBoxAlongId.Items.Count - 1, dictalid[res]);
                }
                readerID.Close();
                fileID.Close();
            }
        }
        private void key_d(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                this.buttonFind_Click(this, new EventArgs());
            }
        }


        private void lineTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(iDToolStripMenuItem.Checked == true)
            {
                    iDToolStripMenuItem.Checked = false;
                    lineTypeToolStripMenuItem.Checked = true;

                    ArrayList list = new ArrayList();
                    /*foreach(string i in checkedListBoxAlongId.Items)
                    {
                        list.Add();
                    }*/
                    for (int i = 0; i < checkedListBoxAlongId.Items.Count; ++i)
                    {
                        list.Add(new MySortClass((string)checkedListBoxAlongId.Items[i], checkedListBoxAlongId.GetItemChecked(i)));
                    }
                    checkedListBoxAlongId.Items.Clear();
                    MYComparer comp = new MYComparer();
                    list.Sort(comp);
                    foreach (MySortClass i in list)
                    {
                        checkedListBoxAlongId.Items.Add(i.str);
                        checkedListBoxAlongId.SetItemChecked(checkedListBoxAlongId.Items.Count - 1, i.check);
                        // checkedListBoxXT.Items.Add(i);
                    } 
                    list = new ArrayList();
                    /*foreach(string i in checkedListBoxAlongId.Items)
                    {
                        list.Add();
                    }*/
                    for (int i = 0; i < checkedListBoxAlongId.Items.Count; ++i)
                    {
                        list.Add(new MySortClass((string)checkedListBoxXT.Items[i], checkedListBoxXT.GetItemChecked(i)));
                    }
                    checkedListBoxXT.Items.Clear();
                    comp = new MYComparer();
                    list.Sort(comp);
                    foreach (MySortClass i in list)
                    {
                        checkedListBoxXT.Items.Add(i.str);
                        checkedListBoxXT.SetItemChecked(checkedListBoxXT.Items.Count - 1, i.check);
                        // checkedListBoxXT.Items.Add(i);
                    }

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openForm = new Open(this);
            openForm.Show();
        }

        private void parseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var parseForm = new Parse(this);
            parseForm.Show();
        }

        public void autoscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (autoscaleToolStripMenuItem.Checked)
            {
                autoscaleToolStripMenuItem.Checked = false;
                autoscale = false;
            }
            else
            {
                autoscaleToolStripMenuItem.Checked = true;
                autoscale = true;
            }
            controller.Autoscale = autoscale;
        }

        private void xrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(xrangeToolStripMenuItem.Checked == true)
            {
                xrange = false;
                controller.XRange = false;
                xrangeToolStripMenuItem.Checked = false;
                autoscaleToolStripMenuItem.Enabled = true;
            }
            else
            {
                Form xr = new XRange(this, xfrom, xto);
                this.Enabled = false;
                xr.Show();
            }
        }

        private void yrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yrangeToolStripMenuItem.Checked == true)
            {
                yrange = false;
                controller.YRange = false;
                yrangeToolStripMenuItem.Checked = false;
                autoscaleToolStripMenuItem.Enabled = true;
            }
            else
            {
                Form yr = new YRange(this, yfrom, yto);
                this.Enabled = false;
                yr.Show();
            }
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string pattern = textBoxFind.Text;
            if(pattern == "") 
            {
                MessageBox.Show("Empty pattern");
                return;
            }
            foreach(char c in pattern)
            {
                if (c != '0' && c != '1' && c != '2' && c != '3' && c != '4' && c != '5' &&
                    c != '6' && c != '7' && c != '8' && c != '9' && c != '+' && c != '-' && c != 'E' && c != 'e'
                    && c != '.' && c != ',')
                {
                    MessageBox.Show("Encorect string");
                    return;
                }
            }
            /*int place = checkedListBoxTime.FindString(pattern, findIndex);
            findIndex = place;
            checkedListBoxTime.SelectedIndex = place;*/
            int flag = 0;
            for(int i = findIndex + 1; i < checkedListBoxTime.Items.Count; ++i)
            {
                if(((string)checkedListBoxTime.Items[i]).IndexOf(pattern) != -1)
                {
                    checkedListBoxTime.SelectedIndex = i;
                    findIndex = i;
                    flag = 1;
                    break;
                }
            }
            if(flag == 0)
            {
                findIndex = -1;
            }

        }

        private void tabControl_SelectedIndCha(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                videlitToolStripMenuItem.Enabled = true;
                selectToolStripMenuItem.Enabled = false;
                sortingToolStripMenuItem.Enabled = false;
                styleToolStripMenuItem.Enabled = false;
            }
            else if (tabControl.SelectedIndex == 1)
            {
                videlitToolStripMenuItem.Enabled = true;
                selectToolStripMenuItem.Enabled = true;
                sortingToolStripMenuItem.Enabled = true;
                styleToolStripMenuItem.Enabled = true;
            }
            else if (tabControl.SelectedIndex == 2)
            {
                videlitToolStripMenuItem.Enabled = true;
                selectToolStripMenuItem.Enabled = true;
                sortingToolStripMenuItem.Enabled = true;
                styleToolStripMenuItem.Enabled = true;
            }
            else if (tabControl.SelectedIndex == 3)
            {
                videlitToolStripMenuItem.Enabled = false;
                sortingToolStripMenuItem.Enabled = false;
                styleToolStripMenuItem.Enabled = false;
            }
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form select = new Select(this);
            select.Show();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stl = new Line(this);
            stl.Show();
        }

        private void buttonPlot3d_Click(object sender, EventArgs e)
        {
            string[] tmp = ((string)comboBox3D.SelectedItem).Split(new char[] { ' ' });
            int i = 0;
            string red = "";
            string nam = "";
            foreach(string s in tmp)
            {
                if (i == 0)
                    red = s;
                else if (i == 1)
                    nam += s;
                else
                    nam += " " + s;
                i++;
            }
            this.controller.plot3d(red, (string)comboBox3D.SelectedItem);
            //MessageBox.Show(tmp[0]);
        }


        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK)
            {
                dir = openFileDialog1.FileName.Replace("\\", "/");
                toolStripMenuItem2.Text = dir;
                fileToolStripMenuItem.Enabled = true;
                settingToolStripMenuItem.Enabled = false;
                legendToolStripMenuItem.Enabled = true;
                rangeToolStripMenuItem.Enabled = true;
                if (File.Exists("./Setting/gnuplot.tun"))
                {
                    FileStream file = new FileStream("./Setting/gnuplot.tun", FileMode.Create);
                    StreamWriter filewr = new StreamWriter(file);
                    filewr.WriteLine(dir);
                    filewr.Close();
                    file.Close();
                    System.Windows.Forms.Application.Restart();
                    System.Environment.Exit(0);
                }
                FileStream file2 = new FileStream("./Setting/gnuplot.tun", FileMode.Create);
                StreamWriter filewr2 = new StreamWriter(file2);
                filewr2.WriteLine(dir);
                filewr2.Close();
                file2.Close();
            }
        }

        /*private void buttonPlotCX_Click(object sender, EventArgs e)
        {
            if(checkedListBoxCX.CheckedItems.Count != 0)
            {
                double argv = ((double)(numericUpDownCX.Value));
                controller.ParseCX(argv);
            }
        }*/
      /*  private void tab1_Click(object sender, EventArgs e)
        {
            sortingToolStripMenuItem.Enabled = false;
        }
        private void tab2_Click(object sender, EventArgs e)
        {
            sortingToolStripMenuItem.Enabled = true;
        }
        private void tab3_Click(object sender, EventArgs e)
        {
            sortingToolStripMenuItem.Enabled = true;
        }*/
    }

    public class Data
    {
        public ArrayList d1;
        public ArrayList d2;
        public Data(ArrayList arg1, ArrayList arg2)
        {
            d1 = arg1;
            d2 = arg2;
        }
    }

    public class MySortClass
    {
        public string str;
        public bool check;
        public MySortClass(string str, bool check)
        {
            this.str = str;
            this.check = check;
        }
    }

    public class MYComparer : IComparer
    {

        // Calls CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {

            string tmp = ((MySortClass)x).str;
            string a = "";
            for(int i = 0; i < tmp.Length; ++i)
            {
                if (tmp[i] == '0' || tmp[i] == '1' || tmp[i] == '2' || tmp[i] == '3' || tmp[i] == '4' ||
                    tmp[i] == '5' || tmp[i] == '6' || tmp[i] == '7' || tmp[i] == '8' || tmp[i] == '9' || tmp[i] == ' ')
                {
                    continue;
                }
                else
                {
                    a += tmp[i];
                }
            }
            tmp = ((MySortClass)y).str;
            string b = "";
            for (int i = 0; i < tmp.Length; ++i)
            {
                if (tmp[i] == '0' || tmp[i] == '1' || tmp[i] == '2' || tmp[i] == '3' || tmp[i] == '4' ||
                    tmp[i] == '5' || tmp[i] == '6' || tmp[i] == '7' || tmp[i] == '8' || tmp[i] == '9' || tmp[i] == ' ')
                {
                    continue;
                }
                else
                {
                    b += tmp[i];
                }
            }
            return string.Compare(a, b);
        }

    }
}
