using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Collections;
using Tuner;

namespace Parser
{
    public class CParser
    {
        private string filedgrg;
        private string filefgrg;
        public ArrayList columsTun;
        public ArrayList lineTun;
        public CParser(string filedgrg, string filefgrg, ArrayList columsTun, ArrayList lineTun)
        {
            this.filedgrg = filedgrg;
            this.filefgrg = filefgrg;
            this.columsTun = columsTun;
            this.lineTun = lineTun;
        }
        public void Parsetmp()
        {
            FileStream filed = new FileStream(filedgrg, FileMode.Open, FileAccess.Read);
            FileStream filef = new FileStream(filefgrg, FileMode.Open, FileAccess.Read);
            StreamReader readerd = new StreamReader(filed);
            StreamReader readerf = new StreamReader(filef);
            while(! readerd.EndOfStream)
            {
                string str = readerd.ReadLine();
                string[] tmp = str.Split(new char[] {' '});
                int i = 0;
                string num = "";
                string t = "";
                string dt = "";
                string start = "";
                string finish = "";
                string flag = "";
                foreach(string s in tmp)
                {
                    if(s.Trim() != "")
                    {
                        if(i == 0)
                            num = s;
                        if(i == 1)
                            t = s;
                        if(i == 2)
                            dt = s;
                        if(i == 3)
                            start = s;
                        if(i == 4)
                            finish = s;
                        if (i == 5)
                            flag = s;
                        ++i;
                    }
                }
                Console.WriteLine("num: " + num + " t: " + t + " dt: " + dt + " st: " + start + " fin: " + finish + " fl: " + flag);
                Directory.CreateDirectory("C:\\Games\\git\\DataVis\\tmp");
                FileStream filetmp = new FileStream("C:\\Games\\git\\DataVis\\tmp\\tmp" + num,
                    FileMode.Append, FileAccess.Write);
                StreamWriter writertmp = new StreamWriter(filetmp);
                for(int k = Int32.Parse(start); k <= Int32.Parse(finish); ++k)
                {
                    writertmp.WriteLine(readerf.ReadLine());
                    //Console.WriteLine(readerf.ReadLine());
                }
                writertmp.Close();
                filetmp.Close();
                //Thread.Sleep(1000);
                //Console.WriteLine(readerd.ReadLine());
            }
        }
        public void ParseConstT()
        {
            FileStream filed = new FileStream(filedgrg, FileMode.Open, FileAccess.Read);
            FileStream filef = new FileStream(filefgrg, FileMode.Open, FileAccess.Read);
            StreamReader readerd = new StreamReader(filed);
            StreamReader readerf = new StreamReader(filef);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int tmpi = 0;
            /**/
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
            Directory.CreateDirectory("./tmp/ConstT");
            FileStream fileT = new FileStream("./tmp/ConstT/time", FileMode.Create, FileAccess.Write);
            StreamWriter writerT = new StreamWriter(fileT);
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
                    Console.WriteLine("num: " + num + " t: " + t + " dt: " + dt + " st: " + start + " fin: " + finish + " fl: " + flag);
                    writerT.WriteLine(t);
                    FileStream[] files = new FileStream[dict.Count - 1];
                    Dictionary<string, int> dict2 = new Dictionary<string, int>();
                    int tmp3 = 0;
                    foreach(var iter in dict)
                    {
                        if(iter.Key != "x")
                        {
                            files[tmp3] = new FileStream("./tmp/ConstT/" + t + "_x_" + iter.Key, FileMode.Create, FileAccess.Write);
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
                            writers[iter.Value].WriteLine(arr[dict["x"]] + " " + arr[dict[iter.Key]]);
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
                        readerf.ReadLine();
                    }
                }
            }
            writerT.Close();
            fileT.Close();
        }

        public void ParseConstX()
        {
            FileStream filed = new FileStream(filedgrg, FileMode.Open, FileAccess.Read);
            FileStream filef = new FileStream(filefgrg, FileMode.Open, FileAccess.Read);
            StreamReader readerd = new StreamReader(filed);
            StreamReader readerf = new StreamReader(filef);
            SortedSet<string> xList = new SortedSet<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int tmpi = 0;
            /**/
            foreach (DataNode data in columsTun)
            {
                if (data.measure != "служебный")
                    dict.Add(data.reduction, tmpi);
                tmpi++;
            }
            foreach (var i in dict)
            {
                Console.WriteLine(i.Key + " " + i.Value);
            }
            Directory.CreateDirectory("./tmp/ConstX");
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
                    Console.WriteLine("num: " + num + " t: " + t + " dt: " + dt + " st: " + start + " fin: " + finish + " fl: " + flag);
                    ArrayList arrForT = new ArrayList();
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
                        /*
                        foreach (var iter in dict2)
                        {
                            writers[iter.Value].WriteLine(arr[dict["x"]] + " " + arr[dict[iter.Key]]);
                        }*/
                        xList.Add(arr[dict["x"]].ToString());
                        arrForT.Add(arr);
                    }
                    
                    //writerT.WriteLine(t);
                   /* FileStream[] files = new FileStream[dict.Count - 1];
                    Dictionary<string, int> dict2 = new Dictionary<string, int>();
                    int tmp3 = 0;
                    foreach (var iter in dict)
                    {
                        if (iter.Key != "x")
                        {
                            files[tmp3] = new FileStream("./tmp/ConstX/" + t + "_x_" + iter.Key, FileMode.Create, FileAccess.Write);
                            dict2.Add(iter.Key, tmp3);
                            tmp3++;
                        }
                    }
                    StreamWriter[] writers = new StreamWriter[dict.Count - 1];
                    tmp3 = 0;
                    foreach (var iter in files)
                    {
                        writers[tmp3] = new StreamWriter(iter);
                        tmp3++;
                    }*/
                    
                    /*foreach (var iter in writers)
                    {
                        iter.Close();
                    }
                    foreach (var iter in files)
                    {
                        iter.Close();
                    }*/
                }
                else
                {
                    for (int k = Int32.Parse(start); k <= Int32.Parse(finish); ++k)
                    {
                        readerf.ReadLine();
                    }
                }
            }
            FileStream filex = new FileStream("./tmp/ConstX/x", FileMode.Create, FileAccess.Write);
            StreamWriter writerx = new StreamWriter(filex);
            foreach(var iter in xList)
            {
                writerx.WriteLine(iter.ToString());
            }
        }
        public void ParseAlongID()
        {
            FileStream filed = new FileStream(filedgrg, FileMode.Open, FileAccess.Read);
            FileStream filef = new FileStream(filefgrg, FileMode.Open, FileAccess.Read);
            StreamReader readerd = new StreamReader(filed);
            StreamReader readerf = new StreamReader(filef);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            Dictionary<string, int> dictWOX = new Dictionary<string, int>();
            Dictionary<string, int> dictIndextInFile = new Dictionary<string, int>();
            Dictionary<string, ArrayList> fileDic = new Dictionary<string,ArrayList>();
            Dictionary<int, string> times = new Dictionary<int, string>();
            ArrayList files = new ArrayList();
            int tmpi = 0;
            int IDcolom = 0;
            int typeColom = 0;
            /**/
            foreach (DataNode data in columsTun)
            {
                if (data.measure != "служебный")
                    dict.Add(data.reduction, tmpi);
                if (data.reduction == "ID")
                    IDcolom = tmpi;
                if(data.reduction == "type")
                {
                    typeColom = tmpi;
                }
                tmpi++;
            }
            Console.WriteLine(IDcolom);
            Console.WriteLine(typeColom);
            foreach (var i in dict)
            {
                if (i.Key != "x")
                    dictWOX.Add(i.Key, i.Value);
                Console.WriteLine(i.Key + " " + i.Value);
            }
            Directory.CreateDirectory("./tmp/AlongID");
            FileStream fileID = new FileStream("./tmp/AlongID/ID", FileMode.Create, FileAccess.Write);
            StreamWriter writerID = new StreamWriter(fileID);
            while(!readerd.EndOfStream)
            {
                string str = readerd.ReadLine();
                string[] tmp = str.Split(new char[] { ' ' });
                var arr = new ArrayList();
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        arr.Add(s);
                    }
                }
                Console.WriteLine("!!!time" + arr[3].ToString());
                times.Add(Int32.Parse(arr[3].ToString()), arr[1].ToString());
            }
            int lineNum = 0;
            while(!readerf.EndOfStream)
            {
                lineNum++;
                string time = "";
                foreach(var iter in times)
                {
                    if(lineNum <= iter.Key)
                    {
                        time = iter.Value;
                        break;
                    }
                }
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
                if (fileDic.ContainsKey(arr[IDcolom].ToString() + " " + arr[typeColom].ToString()))
                {
                    foreach(var iter in dictWOX)
                    {
                        ArrayList arrlist = fileDic[arr[IDcolom].ToString() + " " + arr[typeColom].ToString()];
                        //Console.WriteLine("count " + arrlist.Count + " " + iter.Value);
                        //((StreamWriter)arrlist[dictIndextInFile[iter.Key]]).WriteLine(arr[dict["x"]] + " " + arr[iter.Value]);
                        ((StreamWriter)arrlist[dictIndextInFile[iter.Key]]).WriteLine(time + " " + arr[iter.Value]);
                        
                    }
                    
                }
                else
                {
                    Console.WriteLine("adas");
                    ArrayList writers = new ArrayList();
                    int flagIndex = 0;
                    foreach(var iter in dictWOX)
                    {
                        FileStream tmpName = new FileStream("./tmp/AlongID/" + arr[IDcolom].ToString() + "_" + arr[typeColom].ToString()+ "_t" + "_" + iter.Key, FileMode.Create, FileAccess.Write);
                        files.Add(tmpName);
                        if(!dictIndextInFile.ContainsKey(iter.Key))
                            dictIndextInFile.Add(iter.Key, flagIndex);
                        ++flagIndex;
                        writers.Add(new StreamWriter(tmpName));
                    }
                    fileDic.Add(arr[IDcolom].ToString() + " " + arr[typeColom].ToString(), writers);
                }
            }
            foreach(ArrayList iter in fileDic.Values)
            {
                foreach(StreamWriter i in iter)
                {
                    i.Close();
                }
            }
            foreach(FileStream iter in files)
            {
                iter.Close();
            }
            foreach(string iter in fileDic.Keys)
            {
                writerID.WriteLine(iter);
            }
            writerID.Close();
            fileID.Close();
            readerf.Close();
            filef.Close();
        }

        public void ParseXT()
        {
            FileStream filed = new FileStream(filedgrg, FileMode.Open, FileAccess.Read);
            FileStream filef = new FileStream(filefgrg, FileMode.Open, FileAccess.Read);
            StreamReader readerd = new StreamReader(filed);
            StreamReader readerf = new StreamReader(filef);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            //Dictionary<string, int> dictWOX = new Dictionary<string, int>();
            //Dictionary<string, int> dictIndextInFile = new Dictionary<string, int>();
            Dictionary<string, StreamWriter> fileDic = new Dictionary<string, StreamWriter>();
            Dictionary<int, string> times = new Dictionary<int, string>();
            ArrayList files = new ArrayList();
            int tmpi = 0;
            int IDcolom = 0;
            int typeColom = 0;
            /**/
            foreach (DataNode data in columsTun)
            {
                if (data.measure != "служебный")
                    dict.Add(data.reduction, tmpi);
                if (data.reduction == "ID")
                    IDcolom = tmpi;
                if(data.reduction == "type")
                {
                    typeColom = tmpi;
                }
                tmpi++;
            }
            Console.WriteLine(IDcolom);
            Console.WriteLine(typeColom);
            /*foreach (var i in dict)
            {
                if (i.Key != "x")
                    dictWOX.Add(i.Key, i.Value);
                Console.WriteLine(i.Key + " " + i.Value);
            }*/
            Directory.CreateDirectory("./tmp/XT");
            FileStream fileID = new FileStream("./tmp/XT/ID", FileMode.Create, FileAccess.Write);
            StreamWriter writerID = new StreamWriter(fileID);
            while(!readerd.EndOfStream)
            {
                string str = readerd.ReadLine();
                string[] tmp = str.Split(new char[] { ' ' });
                var arr = new ArrayList();
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        arr.Add(s);
                    }
                }
                Console.WriteLine("!!!time" + arr[3].ToString());
                times.Add(Int32.Parse(arr[3].ToString()), arr[1].ToString());
            }
            int lineNum = 0;
            while(!readerf.EndOfStream)
            {
                lineNum++;
                string time = "";
                foreach(var iter in times)
                {
                    if(lineNum <= iter.Key)
                    {
                        time = iter.Value;
                        break;
                    }
                }
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
                if (fileDic.ContainsKey(arr[IDcolom].ToString() + " " + arr[typeColom].ToString()))
                {
                    //foreach(var iter in dictWOX)
                    //{
                        StreamWriter writer = fileDic[arr[IDcolom].ToString() + " " + arr[typeColom].ToString()];
                        //Console.WriteLine("count " + arrlist.Count + " " + iter.Value);
                        //((StreamWriter)arrlist[dictIndextInFile[iter.Key]]).WriteLine(arr[dict["x"]] + " " + arr[iter.Value]);
                       // ((StreamWriter)arrlist[dictIndextInFile[iter.Key]]).WriteLine(time + " " + arr[iter.Value]);
                        writer.WriteLine(arr[dict["x"]] + " " + time);
                        
                   // }
                    
                }
                else
                {
                    Console.WriteLine("adas");
                    //ArrayList writers = new ArrayList();
                    int flagIndex = 0;
                    //foreach(var iter in dictWOX)
                    //{
                        FileStream tmpName = new FileStream("./tmp/XT/" + arr[IDcolom].ToString() + "_" + arr[typeColom].ToString()+ "_x_t", FileMode.Create, FileAccess.Write);
                        files.Add(tmpName);
                        //if(!dictIndextInFile.ContainsKey(iter.Key))
                          //  dictIndextInFile.Add(iter.Key, flagIndex);
                        //++flagIndex;
                        StreamWriter writer = new StreamWriter(tmpName);
                    //}
                    fileDic.Add(arr[IDcolom].ToString() + " " + arr[typeColom].ToString(), writer);
                }
            }
            foreach(StreamWriter iter in fileDic.Values)
            {
                iter.Close();
            }
            foreach(FileStream iter in files)
            {
                iter.Close();
            }
            foreach(string iter in fileDic.Keys)
            {
                writerID.WriteLine(iter);
            }
            writerID.Close();
            fileID.Close();
            readerf.Close();
            filef.Close();
        }
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
