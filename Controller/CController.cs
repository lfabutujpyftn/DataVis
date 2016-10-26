using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tuner;
using Parser;
using System.Collections;
using Plot;
using System.IO;

namespace Controller
{
    public class CController
    {
        public CTuner tuner;
        public CParser parser;
        public Plot.Plot plt;
        public string dir;
        //plt.DrawFile("C:/Games/git/DataVis/GUI/bin/Debug/tmp/ConstT/1.0539576e-002_x_u");
        public CController(string d, string f, string dir)
        {
            tuner = new CTuner();
            tuner.TUN();
            this.dir = dir;
            //tuner.printTun();
            //parser = new CParser("C:\\Games\\git\\DataVis\\new_d.rez","C:\\Games\\git\\DataVis\\new_f.rez", tuner.columFGRGtun, tuner.typeLineTun);
            //parser = new CParser("C:\\Games\\git\\DataVis\\d_grg.rez", "C:\\Games\\git\\DataVis\\f_grg.rez", tuner.columFGRGtun, tuner.typeLineTun);
            parser = new CParser(d, f, dir, tuner.columFGRGtun, tuner.typeLineTun);
           // parser.ParseConstT();
            //parser.ParseConstX();
           // parser.ParseAlongID_XT();
            //parser.ParseXT();
            //parser.Parse();
            plt = new Plot.Plot();
        }
        public CController(string dir)
        {
            tuner = new CTuner();
            tuner.TUN();
            this.dir = dir;
            //tuner.printTun();
            //parser = new CParser("C:\\Games\\git\\DataVis\\new_d.rez","C:\\Games\\git\\DataVis\\new_f.rez", tuner.columFGRGtun, tuner.typeLineTun);
            //parser = new CParser("C:\\Games\\git\\DataVis\\d_grg.rez", "C:\\Games\\git\\DataVis\\f_grg.rez", tuner.columFGRGtun, tuner.typeLineTun);
            //parser = new CParser(d, f, dir, tuner.columFGRGtun, tuner.typeLineTun);
            //parser.ParseConstT();
            //parser.ParseConstX();
            //parser.ParseAlongID();
            //parser.ParseXT();
            //parser.Parse();
            plt = new Plot.Plot();
        }
        public void ParseCT()
        {
            parser.ParseConstT();
        }
        public void ParseAID_XT()
        {
            parser.ParseAlongID_XT();
        }
        /*public void ParseXT()
        {
            parser.ParseXT();
        }*/
        public void ParseCX()
        {
            //parser.ParseConstT();
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
            string variable = "";
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
                    fileList.Add(dir + "/ConstT/" + s + "_x_" + s2);
                    titleList.Add(s2 + ", t = " + s);
                }
                if(s2 != reduct[0].ToString())
                    variable += ", " + s2;
            }
            plt.XTitle = "x";
            plt.YTitle = variable;
            plt.DrawFiles(fileList, titleList);
        }

        public void PlotSelectItemAlongID(ArrayList ID, ArrayList coloms)
        {
            string variable = "";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            Dictionary<string, int> dictFGRGCOL = new Dictionary<string, int>();
            foreach(DataNodeLine node in tuner.typeLineTun)
            {
                dict.Add(node.name, node.reduction);
            }
            Dictionary<string, string> dict2 = new Dictionary<string, string>();
            foreach (DataNodeLine node in tuner.typeLineTun)
            {
                dict2.Add(node.reduction, node.name);
            }

            ArrayList reduct = new ArrayList();
            foreach (string s in coloms)
            {
                string[] tmp = s.Split(new char[] { ' ' });
                reduct.Add(tmp[0]);
            }
            ArrayList idline = new ArrayList();
            ArrayList numline = new ArrayList();
            foreach(string str in ID)
            {
                string[] tmp = str.Split(new char[] { ' ' });
                int flag = 0;
                string res = "";
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        if (flag == 0)
                            idline.Add(s);
                        else if (flag == 1)
                            res = s;
                        else
                            res += " " + s;
                        flag++;
                    }
                }
                numline.Add(dict[res]);
            }
            int tmpi = 1;
            foreach (DataNode data in tuner.columFGRGtun)
            {
                if (data.measure != "служебный")
                    dictFGRGCOL.Add(data.reduction, tmpi);
            }
            int flagi = 0;
            foreach (string id in idline)
            {
                string type = numline[flagi].ToString();
                
                foreach(var iter in dictFGRGCOL)
                {
                    if (!File.Exists(dir + "/AlongID/" + id + "_" + type + "_t_" + iter.Key))
                    {
                         FileStream inFile = new FileStream(dir + "/AlongID_XT/" + id + "_" + type, FileMode.Open, FileAccess.Read);
                         StreamReader inReader = new StreamReader(inFile);
                         FileStream outFile = new FileStream(dir + "/AlongID/" + id + "_" + type + "_t_" + iter.Key, FileMode.Create, FileAccess.Write);
                         StreamWriter outWriter = new StreamWriter(outFile);
                         while (!inReader.EndOfStream)
                         {
                            string str = inReader.ReadLine();
                            string[] tmp = str.Split(new char[] { ' ' });
                            var arr = new ArrayList();
                            foreach (string s in tmp)
                            {
                                if (s.Trim() != "")
                                {
                                    arr.Add(s);
                                }
                            }
                            outWriter.WriteLine(arr[0] + " " + arr[iter.Value]);
                        }
                        inReader.Close();
                        inFile.Close();
                        outWriter.Close();
                        outFile.Close();
                    }
                }
                flagi++;
            }
            ArrayList fileList = new ArrayList();
            ArrayList titleList = new ArrayList();
            variable = reduct[0].ToString();
            foreach (string s2 in reduct)
            {
                tmpi = 0;
                foreach (string s in idline)
                {
                    fileList.Add(dir + "/AlongID/" + s + "_" + numline[tmpi] + "_t_" + s2);
                    titleList.Add(s2 + ", " + dict2[numline[tmpi].ToString()] + ", ID=" + s);
                    tmpi++;
                }
                if (s2 != reduct[0].ToString())
                    variable += ", " + s2;
            }
            plt.XTitle = "t";
            plt.YTitle = variable;
            plt.DrawFiles(fileList, titleList);
        }

        public void PlotSelectItemXT(ArrayList ID)
        {
            string variable = "";
            Dictionary<string, string> dict = new Dictionary<string, string>();
            Dictionary<string, int> dictFGRGCOL = new Dictionary<string, int>();
            foreach (DataNodeLine node in tuner.typeLineTun)
            {
                dict.Add(node.name, node.reduction);
            }
            Dictionary<string, string> dict2 = new Dictionary<string, string>();
            foreach (DataNodeLine node in tuner.typeLineTun)
            {
                dict2.Add(node.reduction, node.name);
            }
            ArrayList idline = new ArrayList();
            ArrayList numline = new ArrayList();
            foreach (string str in ID)
            {
                string[] tmp = str.Split(new char[] { ' ' });
                int flag = 0;
                string res = "";
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        if (flag == 0)
                            idline.Add(s);
                        else if (flag == 1)
                            res = s;
                        else
                            res += " " + s;
                        flag++;
                    }
                }
                numline.Add(dict[res]);
            }
            int tmpi = 1;
            foreach (DataNode data in tuner.columFGRGtun)
            {
               // if (data.measure != "служебный")
                    dictFGRGCOL.Add(data.reduction, tmpi);
            }
            int flagi = 0;
            foreach(string id in idline)
            {
                string type = numline[flagi].ToString();
                if (!File.Exists(dir + "/XT/" + id + "_" + type + "_x_t"))
                {
                    FileStream inFile = new FileStream(dir + "/AlongID_XT/" + id + "_" + type, FileMode.Open, FileAccess.Read);
                    StreamReader inReader = new StreamReader(inFile);
                    FileStream outFile = new FileStream(dir + "/XT/" + id + "_" + type + "_x_t", FileMode.Create, FileAccess.Write);
                    StreamWriter outWriter = new StreamWriter(outFile);
                    while (!inReader.EndOfStream)
                    {
                        string str = inReader.ReadLine();
                        string[] tmp = str.Split(new char[] { ' ' });
                        var arr = new ArrayList();
                        foreach (string s in tmp)
                        {
                            if (s.Trim() != "")
                            {
                                arr.Add(s);
                            }
                        }
                        outWriter.WriteLine(arr[dictFGRGCOL["x"]] + " " + arr[0]);
                    }
                    inReader.Close();
                    inFile.Close();
                    outWriter.Close();
                    outFile.Close();
                }
                flagi++;
            }

            ArrayList fileList = new ArrayList();
            ArrayList titleList = new ArrayList();
            variable = "t";
            tmpi = 0;
            foreach (string s in idline)
            {
                fileList.Add(dir + "/XT/" + s + "_" + numline[tmpi] + "_x_t");
                titleList.Add(dict2[numline[tmpi].ToString()] + ", ID=" + s);
                tmpi++; 
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
            var contr = new CController("C:\\Games\\git\\DataVis\\new_d.rez",
                "C:\\Games\\git\\DataVis\\new_f.rez",
                "C:\\Games\\git\\DataVis\\data");
        }
    }
}
