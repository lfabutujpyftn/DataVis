using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Collections;

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
        public CTuner()
        {
            columFGRGtun = new ArrayList();
            typeLineTun = new ArrayList();
            initDirectory();
            initColumnFGRG();
            initTypeLine();
        }

        public void initDirectory()
        {
            if (!Directory.Exists("./Setting"))
            {
                Directory.CreateDirectory("./Setting");
            }
        }

        public void initColumnFGRG()
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
        }

        public void initTypeLine()
        {
            if (!File.Exists("./Setting/TypeLine.tun"))
            {
                FileStream file = new FileStream("./Setting/TypeLine.tun", FileMode.Create);
                StreamWriter filewr = new StreamWriter(file);
                filewr.WriteLine("1 левая стенка");
                filewr.WriteLine("2 полевая точка");
                filewr.WriteLine("4 правая стенка");
                filewr.WriteLine("8 левый КР");
                filewr.WriteLine("16 правый КР");
                filewr.WriteLine("32 левая УВ");
                filewr.WriteLine("64 правая УВ");
                filewr.WriteLine("128 крайняя характеристика ВВР");
                filewr.WriteLine("256 точка на хар-ке");
                filewr.WriteLine("512 фиксированная точка");
                filewr.WriteLine("1024 точка адаптивной сетки");
                filewr.WriteLine("2048 левая входная граница");
                filewr.WriteLine("4096 правая входная граница");
                filewr.WriteLine("4608 атмосфера");
                filewr.WriteLine("5120 камера сгорания");

                filewr.Close();
            }
        }

        public void addColumn(string reduction, string measure, string name)
        {
            FileStream file = new FileStream("./Setting/FGRG.tun", FileMode.Append);
            StreamWriter filewr = new StreamWriter(file);
            filewr.WriteLine(reduction + " " + measure + " " + name);
            filewr.Close();
        }

        public void rmColumn(string name)
        {

        }

        public void addTypeLine(int number, string name)
        {
            FileStream file = new FileStream("./Setting/TypeLine.tun", FileMode.Append);
            StreamWriter filewr = new StreamWriter(file);
            filewr.WriteLine(number.ToString() + " " + name);
            filewr.Close();
        }

        public void rmTypeLine()
        {

        }

        public void TunColums()
        {
            FileStream file = new FileStream("./Setting/FGRG.tun", FileMode.Open, FileAccess.Read);
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
            var tun = new CTuner();
            tun.TUN();
            tun.printTun();
        }
    }
}
