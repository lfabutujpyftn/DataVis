using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using Tuner;

namespace GUI
{
    public partial class Select : Form
    {
        private MainForm mainForm;
        private ArrayList linelst;
        private ArrayList comblst;
        public Select(MainForm f)
        {
            InitializeComponent();
            mainForm = f;
        }

        private void Select_Load(object sender, EventArgs e)
        {
            mainForm.Enabled = false;

            linelst = mainForm.controller.getLineType();
            comblst = new ArrayList();
            int count = 0;
            foreach (DataNodeLine i in linelst)
            {
                Label tmplbl = new Label();
                tmplbl.Text = i.name;
                tmplbl.Width = label1.Width;
                tmplbl.Height = label1.Height;
                tmplbl.AutoSize = true;
                tmplbl.Location = new Point(label1.Location.X, label1.Location.Y + (comboBox1.Height + 10) * count);

                ComboBox tmpcmb = new ComboBox();
                tmpcmb.Width = comboBox1.Width;
                tmpcmb.Height = comboBox1.Height;
                tmpcmb.Location = new Point(comboBox1.Location.X, comboBox1.Location.Y + (comboBox1.Height + 10) * count);
                tmpcmb.Items.Add("Skip"); 
                tmpcmb.Items.Add("Select all");
                tmpcmb.Items.Add("Clean all");
               // tmpcmb.Items.Add("Select every n");
                tmpcmb.SelectedIndex = 0;

                comblst.Add(tmpcmb);

                count++;
                this.Controls.Add(tmplbl);
                this.Controls.Add(tmpcmb);

            }
        }
        private void Select_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainForm.Enabled = true;

            Dictionary<string, int> dict = new Dictionary<string, int>();
            int flag = 0;
            foreach(DataNodeLine i in linelst)
            {
                dict.Add(i.name, ((ComboBox)comblst[flag]).SelectedIndex);
                flag++;
            }
            for (int i = 0; i < mainForm.checkedListBoxAlongId.Items.Count; ++i)
            {
                flag = 0;
                string curstr = mainForm.checkedListBoxAlongId.Items[i].ToString();
                string[] tmp = curstr.Split(new char[] { ' ' });
                string res = "";

               // MessageBox.Show(curstr);
                foreach(string s in tmp)
                {
                    if(s.Trim() != "")
                    {
                        if (flag == 0)
                        {
                            flag++;
                            continue;
                        }
                        else if (flag == 1)
                        {
                            flag++;
                            res += s;
                        }
                        else
                            res += " " + s;
                    }
                }
                //MessageBox.Show(res + " " + dict[res]);
                if(dict[res] == 1)
                {
                    if(mainForm.tabControl.SelectedIndex == 1)
                        mainForm.checkedListBoxAlongId.SetItemChecked(i, true);
                    if (mainForm.tabControl.SelectedIndex == 2)
                        mainForm.checkedListBoxXT.SetItemChecked(i, true);
                }
                else if (dict[res] == 0)
                {
                    //mainForm.checkedListBoxXT.SetItemChecked(i, mainForm.checkedListBoxAlongId.GetItemChecked(i));
                    continue;
                    //mainForm.checkedListBoxAlongId.SetItemChecked(i, true);
                }
                else if (dict[res] == 2)
                {
                    if (mainForm.tabControl.SelectedIndex == 1)
                        mainForm.checkedListBoxAlongId.SetItemChecked(i, false);
                    if (mainForm.tabControl.SelectedIndex == 2)
                        mainForm.checkedListBoxXT.SetItemChecked(i, false);
                }
            }
        }
    }
}
