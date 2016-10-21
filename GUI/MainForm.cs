using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private CController controller;
        private Form main;
        public MainForm(Form f)
        {
            InitializeComponent();
            controller = new CController();
            main = f;
            main.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach(DataNode s in controller.getColums())
            {
                if(s.reduction != "x")
                    if (s.measure != "служебный")
                    {
                        checkedListBoxColoms.Items.Add(s.reduction + " " + s.name);
                        checkedListBoxColAlongId.Items.Add(s.reduction + " " + s.name);
                    }
            }
            FileStream fileT = new FileStream("./tmp/ConstT/time", FileMode.Open, FileAccess.Read);
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

            FileStream fileID = new FileStream("./tmp/AlongID/ID", FileMode.Open, FileAccess.Read);
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
            }
            readerID.Close();
            fileID.Close();
        }
        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            main.Enabled = true;
        }

        private void buttonPlotCT_Click(object sender, EventArgs e)
        {
            if(checkedListBoxColoms.CheckedItems.Count != 0 && checkedListBoxTime.CheckedItems.Count != 0)
            {
                FileStream fileT = new FileStream("./tmp.tmp", FileMode.Create, FileAccess.Write);
                StreamWriter wT = new StreamWriter(fileT);
                ArrayList time = new ArrayList();
                ArrayList coloms = new ArrayList();
                foreach (string s in checkedListBoxTime.CheckedItems)
                {
                    wT.WriteLine(s);
                    time.Add(s);
                }
                foreach (string s in checkedListBoxColoms.CheckedItems)
                {
                    wT.WriteLine(s);
                    coloms.Add(s);
                }
                wT.Close();
                fileT.Close();
                controller.PlotSelectItemConstT(time, coloms);
            }
        }

        private void buttonPlotAlongId_Click(object sender, EventArgs e)
        {
            if (checkedListBoxAlongId.CheckedItems.Count != 0 && checkedListBoxColAlongId.CheckedItems.Count != 0)
            {
                FileStream fileID = new FileStream("./tmp.tmp", FileMode.Create, FileAccess.Write);
                StreamWriter wID = new StreamWriter(fileID);
                ArrayList ID = new ArrayList();
                ArrayList coloms = new ArrayList();
                foreach (string s in checkedListBoxAlongId.CheckedItems)
                {
                    wID.WriteLine(s);
                    ID.Add(s);
                }
                foreach (string s in checkedListBoxColAlongId.CheckedItems)
                {
                    wID.WriteLine(s);
                    coloms.Add(s);
                }
                wID.Close();
                fileID.Close();
                controller.PlotSelectItemAlongID(ID, coloms);
            }
        }

        private void buttonPlotXt_Click(object sender, EventArgs e)
        {
            if (checkedListBoxXT.CheckedItems.Count != 0)
            {
                FileStream fileID = new FileStream("./tmp.tmp", FileMode.Create, FileAccess.Write);
                StreamWriter wID = new StreamWriter(fileID);
                ArrayList ID = new ArrayList();
                //ArrayList coloms = new ArrayList();
                foreach (string s in checkedListBoxXT.CheckedItems)
                {
                    wID.WriteLine(s);
                    ID.Add(s);
                }
                wID.Close();
                fileID.Close();
                controller.PlotSelectItemXT(ID);
            }
        }
    }
}
