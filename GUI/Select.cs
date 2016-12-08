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
        private ArrayList numlst;
        private ArrayList lblst;
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
            numlst = new ArrayList();
            lblst = new ArrayList();
            int count = 0;
            foreach (DataNodeLine i in linelst)
            {
                Label tmplbl = new Label();
                tmplbl.Text = i.name;
                tmplbl.Width = label1.Width;
                tmplbl.Height = label1.Height;
                tmplbl.AutoSize = true;
                tmplbl.Location = new Point(label1.Location.X, label1.Location.Y + (comboBox1.Height + 10) * count);

                Label tmplbl2 = new Label();
                tmplbl2.Text = label2.Text;
                tmplbl2.Width = label2.Width;
                tmplbl2.Height = label2.Height;
                tmplbl2.AutoSize = true;
                tmplbl2.Location = new Point(label2.Location.X, label2.Location.Y + (comboBox1.Height + 10) * count);
                //tmplbl2.Visible = false;
                tmplbl2.Enabled = false;
                lblst.Add(tmplbl2);

                NumericUpDown tmpnum = new NumericUpDown();
                tmpnum.Width = numericUpDown1.Width;
                tmpnum.Height = numericUpDown1.Height;
                tmpnum.Location = new Point(numericUpDown1.Location.X, label2.Location.Y + (comboBox1.Height + 10) * count);
                tmpnum.Maximum = numericUpDown1.Maximum;
                tmpnum.Minimum = numericUpDown1.Minimum;
                tmpnum.Increment = numericUpDown1.Increment;
                //tmpnum.Visible = false;
                tmpnum.Enabled = false;
                numlst.Add(tmpnum);

                ComboBox tmpcmb = new ComboBox();
                tmpcmb.Width = comboBox1.Width;
                tmpcmb.Height = comboBox1.Height;
                tmpcmb.Location = new Point(comboBox1.Location.X, comboBox1.Location.Y + (comboBox1.Height + 10) * count);
                tmpcmb.Items.Add("Skip"); 
                tmpcmb.Items.Add("Select all");
                tmpcmb.Items.Add("Clean all");
                tmpcmb.Items.Add("Every n");
               // tmpcmb.Items.Add("Select every n");
                tmpcmb.SelectedIndex = 0;
                tmpcmb.SelectedValueChanged += new EventHandler(change_val);

                comblst.Add(tmpcmb);

                count++;
                this.Controls.Add(tmplbl);
                this.Controls.Add(tmplbl2);
                this.Controls.Add(tmpcmb);
                this.Controls.Add(tmpnum);

            }
            Button butOk = new Button();
            butOk.Width = button1.Width;
            butOk.Height = button1.Height;
            butOk.Location = new Point(button1.Location.X, button1.Location.Y + (comboBox1.Height + 10) * count);
            butOk.Text = "Ok";
            butOk.Click += new EventHandler(button_Click);
            this.Controls.Add(butOk);
        }

        public void change_val(object sender, EventArgs e)
        {
            if(((ComboBox)sender).SelectedIndex == 3)
            {
                int i = 0;
                foreach(ComboBox c in comblst)
                {
                    if(c == (ComboBox)sender)
                    {
                        break;
                    }
                    ++i;
                }
                //MessageBox.Show("qwqw " + i);
                ((Label)lblst[i]).Enabled = true;
                ((NumericUpDown)numlst[i]).Enabled = true;
            }
            if (((ComboBox)sender).SelectedIndex != 3)
            {
                int i = 0;
                foreach (ComboBox c in comblst)
                {
                    if (c == (ComboBox)sender)
                    {
                        break;
                    }
                    ++i;
                }
                //MessageBox.Show("qwqw " + i);
                ((Label)lblst[i]).Enabled = false;
                ((NumericUpDown)numlst[i]).Enabled = false;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            Dictionary<string, int> dict2 = new Dictionary<string, int>();
            Dictionary<string, NumericUpDown> dict3 = new Dictionary<string, NumericUpDown>();
            int flag = 0;
            foreach (DataNodeLine i in linelst)
            {
                dict.Add(i.name, ((ComboBox)comblst[flag]).SelectedIndex);
                dict3.Add(i.name, ((NumericUpDown)numlst[flag]));
                dict2.Add(i.name, Decimal.ToInt32((dict3[i.name]).Value));
                flag++;
            }
            for (int i = 0; i < mainForm.checkedListBoxAlongId.Items.Count; ++i)
            {
                flag = 0;
                string curstr = mainForm.checkedListBoxAlongId.Items[i].ToString();
                string[] tmp = curstr.Split(new char[] { ' ' });
                string res = "";

                // MessageBox.Show(curstr);
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
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
                if (dict[res] == 1)
                {
                    if (mainForm.tabControl.SelectedIndex == 1)
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
                else if (dict[res] == 3)
                {
                    if(dict2[res] == (dict3[res]).Value)
                    {
                        if (mainForm.tabControl.SelectedIndex == 1)
                            mainForm.checkedListBoxAlongId.SetItemChecked(i, true);
                        if (mainForm.tabControl.SelectedIndex == 2)
                            mainForm.checkedListBoxXT.SetItemChecked(i, true);
                        dict2[res] = 0;

                    }
                    dict2[res]++;
                }
            }
            this.Close();
        }
        private void Select_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainForm.Enabled = true;
        }
    }
}
