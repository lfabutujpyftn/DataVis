﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Collections;
using Tuner;
using System.Windows.Forms;
using System.Globalization;

namespace Parser
{
    public class CParser
    {
        private string filedgrg;
        private string filefgrg;
        private string dir;
        public ArrayList columsTun;
        public ArrayList lineTun;
        public CParser(string filedgrg, string filefgrg, string dir, ArrayList columsTun, ArrayList lineTun)
        {
            this.filedgrg = filedgrg;
            this.filefgrg = filefgrg;
            this.dir = dir;
            this.columsTun = columsTun;
            this.lineTun = lineTun;
           /* if(Directory.Exists(dir))
            {
                Directory.Delete(dir, true);
            }*/
        }

        public CParser(string dir, ArrayList columsTun, ArrayList lineTun)
        {
            this.filedgrg = "";
            this.filefgrg = "";
            this.dir = dir;
            this.columsTun = columsTun;
            this.lineTun = lineTun;
        }
        
        
        public void ParseConstT()
        {
            FileStream filed = new FileStream(filedgrg, FileMode.Open, FileAccess.Read);
            FileStream filef = new FileStream(filefgrg, FileMode.Open, FileAccess.Read);
            StreamReader readerd = new StreamReader(filed);
            StreamReader readerf = new StreamReader(filef);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int tmpi = 0;
            foreach(DataNode data in columsTun)
            {
                if(data.measure != "служебный")
                    dict.Add(data.reduction, tmpi);
                tmpi++;
            }
            foreach(var i in dict)
            {
                Console.WriteLine(i.Key + " " + i.Value);
            }
            Directory.CreateDirectory(dir + "/ConstT");
            FileStream fileT = new FileStream(dir + "/ConstT/time", FileMode.Create, FileAccess.Write);
            StreamWriter writerT = new StreamWriter(fileT);
            int countLineF = 0;
            while (!readerd.EndOfStream)
            {
                string str = readerd.ReadLine();
                string[] tmp = str.Split(new char[] { ' ' });
                int i = 0;
                string num = "";
                string t = "";
                string dt = "";
                string start = "";
                string finish = "";
                string flag = "";
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 0)
                            num = s;
                        if (i == 1)
                            t = s;
                        if (i == 2)
                            dt = s;
                        if (i == 3)
                            start = s;
                        if (i == 4)
                            finish = s;
                        if (i == 5)
                            flag = s;
                        ++i;
                    }
                }
                
                if (flag == "0")
                {
                    //Console.WriteLine("num: " + num + " t: " + t + " dt: " + dt + " st: " + start + " fin: " + finish + " fl: " + flag);
                    writerT.WriteLine(t + "      " + num);
                    FileStream[] files = new FileStream[dict.Count - 1];
                    Dictionary<string, int> dict2 = new Dictionary<string, int>();
                    int tmp3 = 0;
                    foreach(var iter in dict)
                    {
                        if(iter.Key != "X")
                        {
                            files[tmp3] = new FileStream(dir + "/ConstT/" + t + "_x_" + iter.Key, FileMode.Create, FileAccess.Write);
                            dict2.Add(iter.Key, tmp3);
                            tmp3++;
                        }
                    }
                    StreamWriter[] writers = new StreamWriter[dict.Count - 1];
                    tmp3 = 0;
                    foreach(var iter in files)
                    {
                        writers[tmp3] = new StreamWriter(iter);
                        tmp3++;
                    }
                    for (int k = Int32.Parse(start); k <= Int32.Parse(finish); ++k)
                    {
                        countLineF++;
                        string str2 = readerf.ReadLine();
                        string[] tmp2 = str2.Split(new char[] { ' ' });
                        var arr = new ArrayList();
                        foreach (string s in tmp2)
                        {
                            if (s.Trim() != "")
                            {
                                arr.Add(s);
                            }
                        }
                        foreach(var iter in dict2)
                        {
                            writers[iter.Value].WriteLine(arr[dict["X"]] + " " + arr[dict[iter.Key]]);
                        }

                    }
                    foreach(var iter in writers)
                    {
                        iter.Close();
                    }
                    foreach(var iter in files)
                    {
                        iter.Close();
                    }
                }
                else
                {
                    for (int k = Int32.Parse(start); k <= Int32.Parse(finish); ++k)
                    {
                        countLineF++;
                        readerf.ReadLine();
                    }
                }
            }
           // MessageBox.Show("const t");
            Console.WriteLine("countLine " + countLineF);
            writerT.Close();
            fileT.Close();
        }

        public void ParseConstXall()
        {

            Console.WriteLine("start");
            FileStream filef = new FileStream(filefgrg, FileMode.Open, FileAccess.Read);
            StreamReader readerf = new StreamReader(filef);
            Directory.CreateDirectory(dir + "/ConstXA");
            FileStream fileX = new FileStream(dir + "/ConstXA/x", FileMode.Create, FileAccess.Write);
            StreamWriter writerX = new StreamWriter(fileX);
            //=========
            int xcolom = 0;
            int tmpi = 0;
            double min = 0;
            double max = 0;
            foreach (DataNode data in columsTun)
            {
                if (data.reduction == "X")
                    xcolom = tmpi;
                tmpi++;
            }
            
            int columLine = 0;
            while (!readerf.EndOfStream)
            {
                ++columLine;
                if (columLine % 1000000 == 0)
                    Console.WriteLine(columLine);
                string str = readerf.ReadLine();
                string[] tmp = str.Split(new char[] { ' ' });
                var arr = new ArrayList();
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        arr.Add(s);
                    }
                }
                string x = arr[xcolom].ToString();
                double tmpX = Double.Parse(x);
                Console.WriteLine(x + " " + tmpX);
                if (min > tmpX)
                    min = tmpX;
                if (max < tmpX)
                    max = tmpX;
                
            }
            writerX.WriteLine(min);
            writerX.WriteLine(max);
            readerf.Close();
            filef.Close();
            writerX.Close();
            fileX.Close();
           
        }

        public void ParseConstXall(double value)
        {
            FileStream filed = new FileStream(filedgrg, FileMode.Open, FileAccess.Read);
            FileStream filef = new FileStream(filefgrg, FileMode.Open, FileAccess.Read);
            StreamReader readerd = new StreamReader(filed);
            StreamReader readerf = new StreamReader(filef);
            int tmpi = 0;
            int xcolom = 0;
            foreach (DataNode data in columsTun)
            {
                if (data.reduction == "X")
                    xcolom = tmpi;
                tmpi++;
            }
            FileStream fileX = new FileStream(dir + "/ConstXA/" + value.ToString(), FileMode.Create, FileAccess.Write);
            StreamWriter writerX = new StreamWriter(fileX);
            while (!readerd.EndOfStream)
            {
                string str = readerd.ReadLine();
                string[] tmp = str.Split(new char[] { ' ' });
                int i = 0;
                string num = "";
                string t = "";
                string dt = "";
                string start = "";
                string finish = "";
                string flag = "";
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 0)
                            num = s;
                        if (i == 1)
                            t = s;
                        if (i == 2)
                            dt = s;
                        if (i == 3)
                            start = s;
                        if (i == 4)
                            finish = s;
                        if (i == 5)
                            flag = s;
                        ++i;
                    }
                }
                int tmpflag = 0;
                for (int k = Int32.Parse(start); k <= Int32.Parse(finish); ++k)
                {
                    string str2 = readerf.ReadLine();
                    string[] tmp2 = str2.Split(new char[] { ' ' });
                    var arr = new ArrayList();
                    foreach (string s in tmp2)
                    {
                        if (s.Trim() != "")
                        {
                            arr.Add(s);
                        }
                    }
                    double tmpValue = Double.Parse(arr[xcolom].ToString());
                    if(tmpflag == 0 && tmpValue > value)
                    {
                        if (value - tmpValue < 0.01)
                        {
                            tmpflag = 1;
                            writerX.WriteLine(str2);
                        }
                    }
                }
            }
            readerd.Close();
            readerf.Close();
            filed.Close();
            filef.Close();
            writerX.Close();
            fileX.Close();
        }
        public void ParseAlongID_XT()
        {
            Console.WriteLine("start");
            FileStream filed = new FileStream(filedgrg, FileMode.Open, FileAccess.Read);
            FileStream filef = new FileStream(filefgrg, FileMode.Open, FileAccess.Read);
            StreamReader readerd = new StreamReader(filed);
            StreamReader readerf = new StreamReader(filef);
            Dictionary<string, StreamWriter> fileDic = new Dictionary<string, StreamWriter>();
            Dictionary<int, string> times = new Dictionary<int, string>();
            ArrayList files = new ArrayList();
            int tmpi = 0;
            int IDcolom = 0;
            int typeColom = 0;
            foreach (DataNode data in columsTun)
            {
                if (data.reduction == "ID")
                    IDcolom = tmpi;
                if (data.reduction == "TL")
                {
                    typeColom = tmpi;
                }
                tmpi++;
            }
            Console.WriteLine(IDcolom);
            Console.WriteLine(typeColom);
           /* foreach (var i in dict)
            {
                if (i.Key != "X")
                    dictWOX.Add(i.Key, i.Value);
                Console.WriteLine(i.Key + " " + i.Value);
            }*/
            Directory.CreateDirectory(dir + "/AlongID_XT");
            Directory.CreateDirectory(dir + "/AlongID");
            Directory.CreateDirectory(dir + "/XT");
            FileStream fileID = new FileStream(dir + "/AlongID_XT/ID", FileMode.Create, FileAccess.Write);
            StreamWriter writerID = new StreamWriter(fileID);
            //=========
            int columLine = 0;
            while (!readerd.EndOfStream)
            {
                string str = readerd.ReadLine();
                string[] tmp = str.Split(new char[] { ' ' });
                int i = 0;
                string num = "";
                string t = "";
                string dt = "";
                string start = "";
                string finish = "";
                string flag = "";
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 0)
                            num = s;
                        if (i == 1)
                            t = s;
                        if (i == 2)
                            dt = s;
                        if (i == 3)
                            start = s;
                        if (i == 4)
                            finish = s;
                        if (i == 5)
                            flag = s;
                        ++i;
                    }
                }
                for (int k = Int32.Parse(start); k <= Int32.Parse(finish); ++k)
                {
                    columLine++;
                    if (columLine % 100000 == 0)
                        Console.WriteLine(columLine);
                    string str2 = readerf.ReadLine();
                    string[] tmp2 = str2.Split(new char[] { ' ' });
                    var arr = new ArrayList();
                    foreach (string s in tmp2)
                    {
                        if (s.Trim() != "")
                        {
                            arr.Add(s);
                        }
                    }
                    string id = arr[IDcolom].ToString();
                    string type = arr[typeColom].ToString();
                    string key = id + " " + type;
                    if (fileDic.ContainsKey(key))
                    {
                        (fileDic[key]).WriteLine(t + " " + str2);
                    }
                    else
                    {
                        FileStream tmpName = new FileStream(dir + "/AlongID_XT/" + arr[IDcolom].ToString() + "_" + type, FileMode.Create, FileAccess.Write);
                        files.Add(tmpName);
                        StreamWriter writer = new StreamWriter(tmpName);
                        writer.WriteLine(t + " " + str2);
                        fileDic.Add(id + " " + type, writer);
                    }
                }
            }
            //==========
            foreach (StreamWriter iter in fileDic.Values)
            {
                iter.Close();
            }
            foreach (FileStream iter in files)
            {
                iter.Close();
            }
            foreach (string iter in fileDic.Keys)
            {
                writerID.WriteLine(iter);
            }
            //MessageBox.Show("alongid xt");
            writerID.Close();
            fileID.Close();
            readerf.Close();
            filef.Close();
        }
        


        //=======================
        public void Parse3d()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Console.WriteLine("start");
            FileStream filed = new FileStream(filedgrg, FileMode.Open, FileAccess.Read);
            FileStream filef = new FileStream(filefgrg, FileMode.Open, FileAccess.Read);
            StreamReader readerd = new StreamReader(filed);
            StreamReader readerf = new StreamReader(filef);
            Dictionary<int, StreamWriter> fileDic = new Dictionary<int, StreamWriter>();
            ArrayList files = new ArrayList();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int tmpi = 0;
            int TLCol = 0;
            foreach (DataNode data in columsTun)
            {
                if (data.reduction == "TL")
                    TLCol = tmpi;
                if (data.measure != "служебный")
                    if (data.reduction != "X")
                        dict.Add(data.reduction, tmpi);
                tmpi++;
            }
            Console.WriteLine("tl colom " + TLCol);
            foreach(var i in dict)
            {
                Console.WriteLine(i.Key + " " + i.Value);
            }
            Directory.CreateDirectory(dir + "/3d");
            foreach (var i in dict)
            {
                FileStream tmpName = new FileStream(dir + "/3d/" + i.Key, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(tmpName);
                fileDic.Add(i.Value, writer);
                files.Add(tmpName);
            }
            int columLine = 0;
            while (!readerd.EndOfStream)
            {
                string str = readerd.ReadLine();
                string[] tmp = str.Split(new char[] { ' ' });
                int i = 0;
                string num = "";
                string t = "";
                string dt = "";
                string start = "";
                string finish = "";
                string flag = "";
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 0)
                            num = s;
                        if (i == 1)
                            t = s;
                        if (i == 2)
                            dt = s;
                        if (i == 3)
                            start = s;
                        if (i == 4)
                            finish = s;
                        if (i == 5)
                            flag = s;
                        ++i;
                    }
                }
                if(flag == "0")
                {
                    foreach(var f in fileDic)
                    {
                        f.Value.WriteLine("");
                    }
                }
                for (int k = Int32.Parse(start); k <= Int32.Parse(finish); ++k)
                {
                    columLine++;
                    if (columLine % 100000 == 0)
                        Console.WriteLine(columLine);
                    string str2 = readerf.ReadLine();
                    if (flag != "0")
                       continue;
                    if (columLine % 1 != 0)
                    {
                        continue;
                    }
                    string[] tmp2 = str2.Split(new char[] { ' ' });
                    var arr = new ArrayList();
                    foreach (string s in tmp2)
                    {
                        if (s.Trim() != "")
                        {
                            arr.Add(s);
                        }
                    }
                    foreach(var f in fileDic)
                    {
                        
                        if (arr[TLCol].ToString() == "8")
                        {
                            //MessageBox.Show("8");
                            double xc = Double.Parse(arr[0].ToString());
                            xc -= 0.000001;
                            f.Value.WriteLine(xc + " " + t + " " + arr[f.Key]);
                        }
                        else if (arr[TLCol].ToString() == "16")
                        {
                            double xc = Double.Parse(arr[0].ToString());
                            xc -= 0.0;
                            f.Value.WriteLine(xc + " " + t + " " + arr[f.Key]);
                        }
                        else if (arr[TLCol].ToString() == "32")
                        {
                            double xc = Double.Parse(arr[0].ToString());
                            xc += 0.000001;
                            f.Value.WriteLine(xc + " " + t + " " + arr[f.Key]);
                        }
                        else if (arr[TLCol].ToString() == "64")
                        {
                            double xc = Double.Parse(arr[0].ToString());
                            xc += 0.000002;
                            f.Value.WriteLine(xc + " " + t + " " + arr[f.Key]);
                        }
                        else
                        {
                            f.Value.WriteLine(arr[0] + " " + t + " " + arr[f.Key]);
                        }
                    }
                }
            }
            readerf.Close();
            filef.Close();
            foreach (var f in fileDic)
            {
                f.Value.Close();
            }
            foreach (FileStream f in files)
            {
                f.Close();
            }
            //writer.Close();
            //tmpName.Close();
        }

        //==========================


    }



    public class Test
    {
        static void Main()
        {
            //CParser pars = new CParser("C:\\Games\\git\\DataVis\\d_grg.rez","C:\\Games\\git\\DataVis\\f_grg.rez");
            //pars.Parsetmp();

        }
    }
}
