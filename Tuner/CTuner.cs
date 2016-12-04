using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Collections;
using System.Globalization;
using System.Windows.Forms;

namespace Tuner
{
    public class DataNode
    {
        public string reduction;
        public string measure;
        public string name;
        public DataNode(string reduction, string measure, string name)
        {
            this.reduction = reduction;
            this.measure = measure;
            this.name = name;
        }

    }
    public class DataNodeLine
    {
        public string reduction;
        public string name;
        public DataNodeLine(string reduction, string name)
        {
            this.reduction = reduction;
            this.name = name;
        }

    }
    public class CTuner
    {
        public ArrayList columFGRGtun;
        public ArrayList typeLineTun;
        public string dir;
        public string o;
        public CTuner(string dir, string o)
        {
            columFGRGtun = new ArrayList();
            typeLineTun = new ArrayList();
            this.dir = dir;
            this.o = o;
            initDirectory();
            createFGRGTUN(o);
           // initColumnFGRG();
            initTypeLine();
        }

        public CTuner(string dir)
        {
            columFGRGtun = new ArrayList();
            typeLineTun = new ArrayList();
            this.dir = dir;
            initDirectory();
           // initColumnFGRG();
            initTypeLine();
        }

        public void initDirectory()
        {
            if (!Directory.Exists("./Setting"))
            {
                Directory.CreateDirectory("./Setting");
            } 
            if (!Directory.Exists(dir + "/Setting"))
            {
                Directory.CreateDirectory(dir + "/Setting");
            }
        }

        public void createFGRGTUN(string o)
        {
            FileStream file = new FileStream(dir + "/Setting/FGRG.tun", FileMode.Create);
            FileStream fileo = new FileStream(o, FileMode.Open);
            StreamWriter filewr = new StreamWriter(file);
            StreamReader fileord = new StreamReader(fileo, System.Text.Encoding.Default);
            while(!fileord.EndOfStream)
            {
                string str = fileord.ReadLine();
               // Console.WriteLine(str);
                string[] tmp = str.Split(new char[] { '\'' });
                ArrayList arr = new ArrayList();
                foreach (string s in tmp)
                {
                    arr.Add(s);
                }
                /*foreach(string s in arr)
                {
                    Console.Write("!" + s+ "!");
                }*/
                string res = "";
                res += arr[1] + " ";
                if (((string)arr[arr.Count - 2]).Trim() == "")
                    res += "служебный";
                else
                    res += arr[arr.Count - 2];
                res += " " + arr[3];
                filewr.WriteLine(res);
                Console.WriteLine(res);
            }
            fileord.Close();
            filewr.Close();
            file.Close();
            fileo.Close();
        }

       /* public void initColumnFGRG()
        {
            if(!File.Exists("./Setting/FGRG.tun"))
            {
                FileStream file = new FileStream("./Setting/FGRG.tun", FileMode.Create);
                StreamWriter filewr = new StreamWriter(file);
                filewr.WriteLine("x м координата");
                filewr.WriteLine("D м\\c скорость узла");
                filewr.WriteLine("u м\\c скорость газа");
                filewr.WriteLine("p Pa давление");
                filewr.WriteLine("T K температура");
                filewr.WriteLine("tho кг\\м3 плотность");
                filewr.WriteLine("a м\\с скорость звука");
                filewr.WriteLine("e Дж внутренняя энергия");
                filewr.WriteLine("type служебный тип газа");
                filewr.WriteLine("ID служебный айдиточки");
                filewr.WriteLine("gas_type служебный тип газа");
                filewr.WriteLine("N служебный число компонентов смеси");
                filewr.WriteLine("HO2 моль\\м3 компонента");

                filewr.Close();
            }
        }*/

        public void initTypeLine()
        {
            if (!File.Exists("./Setting/TypeLine.tun"))
            {
                FileStream file = new FileStream("./Setting/TypeLine.tun", FileMode.Create);
                StreamWriter filewr = new StreamWriter(file);
                filewr.WriteLine("1 Левая стенка");
                filewr.WriteLine("2 Полевая точка");
                filewr.WriteLine("4 Правая стенка");
                filewr.WriteLine("8 Левый КР");
                filewr.WriteLine("16 Правый КР");
                filewr.WriteLine("32 Левая УВ");
                filewr.WriteLine("64 Правая УВ");
                filewr.WriteLine("128 Крайняя характеристика ВВР");
                filewr.WriteLine("256 Точка на хар-ке");
                filewr.WriteLine("512 Фиксированная точка");
                filewr.WriteLine("1024 Точка адаптивной сетки");
                filewr.WriteLine("2048 Левая входная граница");
                filewr.WriteLine("4096 Правая входная граница");
                filewr.WriteLine("4608 Атмосфера");
                filewr.WriteLine("5120 Камера сгорания");

                filewr.Close();
            }
        }

        public void TunColums()
        {
            FileStream file = new FileStream(dir + "/Setting/FGRG.tun", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                string[] tmp = str.Split(new char[] { ' ' });
                int i = 0;
                string red = "";
                string meas = "";
                string name = "";
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 0)
                            red = s;
                        if (i == 1)
                            meas = s;
                        if (i == 2)
                        {
                            name = s;
                        }
                        else
                        {
                            name += " " + s;
                        }
                        ++i;
                    }
                }
                columFGRGtun.Add(new DataNode(red, meas, name));
            }
        }
        public void TunLines()
        {
            FileStream file = new FileStream("./Setting/TypeLine.tun", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();
                string[] tmp = str.Split(new char[] { ' ' });
                int i = 0;
                string red = "";
                string name = "";
                foreach (string s in tmp)
                {
                    if (s.Trim() != "")
                    {
                        if (i == 0)
                            red = s;
                        if (i == 1)
                        {
                            name = s;
                        }
                        else
                        {
                            name += " " + s;
                        }
                        ++i;
                    }
                }
                typeLineTun.Add(new DataNodeLine(red, name));
            }
        }

        public void TUN()
        {
            this.TunColums();
            this.TunLines();
        }

        public void printTun()
        {
            Console.WriteLine("FGRG tun");
            foreach(DataNode d in columFGRGtun)
            {
                Console.WriteLine(d.reduction + " " + d.measure + " " + d.name);
            }
            Console.WriteLine("LINE tun");
            foreach (DataNodeLine d in typeLineTun)
            {
                Console.WriteLine(d.reduction + " " + d.name);
            }
        }

       

        
    }
    public class Test
    {
        static void Main()
        {
            var tun = new CTuner("./as", "C:/Владимир/Учеба/Универ/Диплом/testdata/o_grg");
            tun.TUN();
            tun.printTun();
        }
    }
}
