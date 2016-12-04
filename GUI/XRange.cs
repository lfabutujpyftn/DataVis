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
    public partial class XRange : Form
    {
        private MainForm f;
        public XRange(MainForm f, double from, double to)
        {
            InitializeComponent();
            this.f = f;
            numericUpDown1.Value = System.Convert.ToDecimal(from);
            numericUpDown2.Value = System.Convert.ToDecimal(to);
        }

        private void button_Click(object sender, EventArgs e)
        {
            f.xrange = true;
            f.xfrom = System.Convert.ToDouble(numericUpDown1.Value);
            f.xto = System.Convert.ToDouble(numericUpDown2.Value);
            f.Enabled = true;
            f.xrangeToolStripMenuItem.Checked = true;
            f.controller.XRange = true;
            f.controller.XFrom = f.xfrom;
            f.controller.XTo = f.xto;
            if(f.xrangeToolStripMenuItem.Checked == true && f.yrangeToolStripMenuItem.Checked == true)
                f.autoscaleToolStripMenuItem.Enabled = false;
            /*if(f.autoscaleToolStripMenuItem.Checked == true)
            {
                f.autoscaleToolStripMenuItem_Click(this, new EventArgs());
            }*/
            this.Close();
        }

        private void XRange_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            f.Enabled = true;
        }
    }
}
