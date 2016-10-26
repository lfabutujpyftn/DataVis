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
            var openForm = new Open(this);
            openForm.Show();
        }

        private void parseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("QWQW");
            var parseForm = new Parse(this);
            parseForm.Show();
            
        }
    }
}
