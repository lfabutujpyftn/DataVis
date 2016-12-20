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
using Controller;

namespace GUI
{
    public partial class Line : Form
    {
        private MainForm mainForm;
        private ArrayList linelst;
        private ArrayList numlst;
        private ArrayList numptlst;
        private ArrayList butlst;
        public Line(MainForm f)
        {
            InitializeComponent();
            mainForm = f;
        }

        private void Line_Load(object sender, EventArgs e)
        {
            mainForm.Enabled = false;

            linelst = mainForm.controller.getLineType();
            numlst = new ArrayList();
            numptlst = new ArrayList();
            butlst = new ArrayList();
            int count = 0;
            foreach (DataNodeLine i in linelst)
            {
                Label tmplbl = new Label();
                tmplbl.Text = i.name;
                tmplbl.Width = label1.Width;
                tmplbl.Height = label1.Height;
                tmplbl.AutoSize = true;
                tmplbl.Location = new Point(label1.Location.X, label1.Location.Y + (button1.Height + 10) * count);

                Label tmplbl2 = new Label();
                tmplbl2.Text = "depth:";
                tmplbl2.Width = label2.Width;
                tmplbl2.Height = label2.Height;
                tmplbl2.AutoSize = true;
                tmplbl2.Location = new Point(label2.Location.X, label2.Location.Y + (button1.Height + 10) * count);

                Label tmplbl3 = new Label();
                tmplbl3.Text = "style:";
                tmplbl3.Width = label3.Width;
                tmplbl3.Height = label3.Height;
                tmplbl3.AutoSize = true;
                tmplbl3.Location = new Point(label3.Location.X, label3.Location.Y + (button1.Height + 10) * count);

                count++;
                this.Controls.Add(tmplbl);
                this.Controls.Add(tmplbl2);
                this.Controls.Add(tmplbl3);
               // this.Controls.Add(tmpcmb);

            }

            count = 0;
            ArrayList data = mainForm.controller.loadLine();
            foreach (StlLine i in data)
            {
                NumericUpDown tmpnud = new NumericUpDown();
                tmpnud.Width = numericUpDown1.Width;
                tmpnud.Height = numericUpDown1.Height;
                tmpnud.Location = new Point(numericUpDown1.Location.X, numericUpDown1.Location.Y + (button1.Height + 10) * count);
                tmpnud.Minimum = numericUpDown1.Minimum;
                tmpnud.DecimalPlaces = numericUpDown1.DecimalPlaces;
                tmpnud.Maximum = numericUpDown1.Maximum;
                tmpnud.Increment = numericUpDown1.Increment;
                tmpnud.Value = i.num;
                numlst.Add(tmpnud);

                NumericUpDown tmpnudpt = new NumericUpDown();
                tmpnudpt.Width = numericUpDown2.Width;
                tmpnudpt.Height = numericUpDown2.Height;
                tmpnudpt.Location = new Point(numericUpDown2.Location.X, numericUpDown2.Location.Y + (button1.Height + 10) * count);
                tmpnudpt.Minimum = numericUpDown2.Minimum;
                tmpnudpt.DecimalPlaces = numericUpDown2.DecimalPlaces;
                tmpnudpt.Maximum = numericUpDown2.Maximum;
                tmpnudpt.Increment = numericUpDown2.Increment;
                tmpnudpt.Value = i.numpt;
                numptlst.Add(tmpnudpt);

                Button tmpb = new Button();
                tmpb.Width = button1.Width;
                tmpb.Height = button1.Height;
                tmpb.Location = new Point(button1.Location.X, button1.Location.Y + (button1.Height + 10) * count);
                tmpb.Text = "";
                Color clr = Color.FromArgb(i.col);
                tmpb.BackColor = clr;
                tmpb.Click += new EventHandler(button_Click);
                butlst.Add(tmpb);
                this.Controls.Add(tmpnud);
                this.Controls.Add(tmpnudpt);
                this.Controls.Add(tmpb);
                count++;
            }
            Button butOk = new Button();
            butOk.Width = button1.Width;
            butOk.Height = button1.Height;
            butOk.Location = new Point(button1.Location.X, button1.Location.Y + (button1.Height + 10) * count);
            butOk.Text = "Ok";
            butOk.Click += new EventHandler(buttonOk_Click);
            //this.Size.Width = butOk.Location.X + butOk.Size.Width + 10;
            //this.Size.Height = butOk.Location.Y + butOk.Size.Height = 10;
            this.Controls.Add(butOk);
        }
        private void button_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Button btn = (Button)sender;
                btn.BackColor = colorDialog1.Color;
            }
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            //mainForm.Enabled = true;
            ArrayList num = new ArrayList();
            ArrayList numpt = new ArrayList();
            ArrayList col = new ArrayList();
            int flag = 0;
            foreach (var i in numlst)
            {
                num.Add(((NumericUpDown)numlst[flag]).Value.ToString());
                numpt.Add(((NumericUpDown)numptlst[flag]).Value.ToString());
                col.Add(((Button)butlst[flag]).BackColor.ToArgb().ToString());
                flag++;
            }
            mainForm.controller.saveLine(num, numpt, col);
            mainForm.controller.tuner.TunStyle();
            this.Close();
        }

        private void Line_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mainForm.Enabled = true;

            
        }
    }
}
