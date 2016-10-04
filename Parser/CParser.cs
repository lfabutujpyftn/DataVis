using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Parser
{
    public class CParser
    {
        private string filedgrg;
        private string filefgrg;
        public CParser(string filedgrg, string filefgrg)
        {
            this.filedgrg = filedgrg;
            this.filefgrg = filefgrg;
        }
        public void Parse()
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
    }
    public class Test
    {
        static void Main()
        {
            CParser pars = new CParser("C:\\Games\\git\\DataVis\\d_grg.rez","C:\\Games\\git\\DataVis\\f_grg.rez");
            pars.Parse();
        }
    }
}
