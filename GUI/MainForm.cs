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

namespace GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CParser pars = new CParser("C:\\Games\\git\\DataVis\\d_grg.rez", "C:\\Games\\git\\DataVis\\f_grg.rez");
            pars.Parse();
            Plot.Plot plt = new Plot.Plot();
            plt.DrawFile("C:/Games/git/DataVis/tmp/tmp0");
        }
    }
}
