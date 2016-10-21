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
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void parseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("QWQW");
            var mainform = new MainForm(this);
            mainform.Show();
            
        }
    }
}
