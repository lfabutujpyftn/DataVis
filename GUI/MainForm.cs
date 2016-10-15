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
        public MainForm()
        {
            InitializeComponent();
            controller = new CController();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach(DataNode s in controller.getColums())
            {
                if(s.reduction != "x")
                    if (s.measure != "служебный")
                        checkedListBoxColoms.Items.Add(s.reduction + " " + s.name);
            }
            FileStream fileT = new FileStream("./tmp/ConstT/time", FileMode.Open, FileAccess.Read);
            StreamReader readerT = new StreamReader(fileT);
            while (!readerT.EndOfStream)
            {
                checkedListBoxTime.Items.Add(readerT.ReadLine());
            }
            readerT.Close();
            fileT.Close();
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
    }
}
