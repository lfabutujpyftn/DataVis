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
    }
    public class Test
    {
        static void Main()
        {
           // CParser pars = new CParser("C:\\Games\\git\\DataVis\\d_grg.rez","C:\\Games\\git\\DataVis\\f_grg.rez");
            //pars.Parsetmp();
        }
    }
}
