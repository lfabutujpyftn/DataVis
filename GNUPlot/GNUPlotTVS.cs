using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GNUPlot
{
    public class GNUPlotTVS
    {
        private static Process ExtPro;
        private static StreamWriter GnupStWr;

        public GNUPlotTVS(string path)
        {
            ExtPro = new Process();
            ExtPro.StartInfo.FileName = path;
            ExtPro.StartInfo.UseShellExecute = false;
            ExtPro.StartInfo.RedirectStandardInput = true;
            ExtPro.StartInfo.CreateNoWindow = true;
            ExtPro.Start();
            GnupStWr = ExtPro.StandardInput;
        }

        ~GNUPlotTVS( )
        {
            ExtPro.Kill();
        }

        public void Set(string param)
        {
            GnupStWr.WriteLine("set " + param);
        }
        public void Plot(string file, string par)
        {
            GnupStWr.WriteLine("plot " + file + " " + par);
            GnupStWr.Flush();
        }

        public void Plots(ArrayList files, ArrayList param)
        {
            //MessageBox.Show("plots");
            string outSCR = "plot ";
            int i = 0;
            foreach(string s in files)
            {
                outSCR += "\"" + s + "\"" + " " + param[i];
                if(i + 1 != files.Count)
                {
                    outSCR += ", ";
                }
                ++i;
            }
            FileStream fileT = new FileStream("./last2dScript.gp", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileT, System.Text.Encoding.Default);
            writer.Write(outSCR);
            writer.Flush();
            fileT.Close();
            //GnupStWr.WriteLine(outSCR);
            GnupStWr.WriteLine("call \"./last2dScript.gp\"");
            GnupStWr.Flush();
        }

        public void SPlot(string file, string param)
        {

           // MessageBox.Show("splot");

            GnupStWr.WriteLine("splot " + file + " " + param);
            GnupStWr.Flush();
        }
    }
}
