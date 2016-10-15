using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuner;
using Parser;
using System.Collections;
using Plot;

namespace Controller
{
    public class CController
    {
        public CTuner tuner;
        public CParser parser;
        public Plot.Plot plt;
        //plt.DrawFile("C:/Games/git/DataVis/GUI/bin/Debug/tmp/ConstT/1.0539576e-002_x_u");
        public CController()
        {
            tuner = new CTuner();
            tuner.TUN();
            //tuner.printTun();
            parser = new CParser("C:\\Games\\git\\DataVis\\new_d.rez","C:\\Games\\git\\DataVis\\new_f.rez",
                tuner.columFGRGtun, tuner.typeLineTun);
            //parser.ParseConstT();
            plt = new Plot.Plot();
        }

        public ArrayList getLineType()
        {
            return tuner.typeLineTun;
        }

        public ArrayList getColums()
        {
            return tuner.columFGRGtun;
        }

        public void PlotSelectItemConstT(ArrayList time, ArrayList coloms)
        {
            //plt.Close();
            //plt = new Plot.Plot();
            string variable = "";
            /*foreach (DataNode s in tuner.columFGRGtun)
            {
                if(s.name + " " + s.reduction == coloms[0].ToString())
                {
                    variable = s.reduction;

                    break;
                }
            }*/
            ArrayList reduct = new ArrayList();
            foreach(string s in coloms)
            {
                string[] tmp = s.Split(new char[] { ' ' });
                reduct.Add(tmp[0]);
            }
            ArrayList fileList = new ArrayList();
            ArrayList titleList = new ArrayList();
            variable = reduct[0].ToString();
            foreach(string s2 in reduct)
            {   
                foreach(string s in time)
                {
                    fileList.Add("./tmp/ConstT/" + s + "_x_" + s2);
                    titleList.Add(s2 + ", t = " + s);
                }
                if(s2 != reduct[0].ToString())
                    variable += ", " + s2;
            }
            plt.XTitle = "x";
            plt.YTitle = variable;
            plt.DrawFiles(fileList, titleList);
        }
    }
    public class Test
    {
        static void Main()
        {
            Console.WriteLine("hi");
            var contr = new CController();
        }
    }
}
