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
    public partial class YRange : Form
    {
        private MainForm f;
        public YRange(MainForm f, double from, double to)
        {
            InitializeComponent();
            this.f = f;
            numericUpDown1.Value = System.Convert.ToDecimal(from);
            numericUpDown2.Value = System.Convert.ToDecimal(to);
        }

        private void button_Click(object sender, EventArgs e)
        {
            f.yrange = true;
            f.yfrom = System.Convert.ToDouble(numericUpDown1.Value);
            f.yto = System.Convert.ToDouble(numericUpDown2.Value);
            f.Enabled = true;
            f.yrangeToolStripMenuItem.Checked = true;
            f.controller.YRange = true;
            f.controller.YFrom = f.yfrom;
            f.controller.YTo = f.yto;
            if(f.xrangeToolStripMenuItem.Checked == true && f.yrangeToolStripMenuItem.Checked == true)
                f.autoscaleToolStripMenuItem.Enabled = false;
            /*if(f.autoscaleToolStripMenuItem.Checked == true)
            {
                f.autoscaleToolStripMenuItem_Click(this, new EventArgs());
            }*/
            this.Close();
        }
    }
}
