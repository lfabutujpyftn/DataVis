﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plot
{
    public class Plot: IPlot
    {
        //private Color _color;
        private string _color;
        private DrawType _drawType;
        private string _xTitle;
        private string _yTitle;
        private string _title;
        private bool legend;
        private bool autoscale;
        private bool xrange;
        private double xfrom;
        private double xto;
        private bool yrange;
        private double yfrom;
        private double yto;
        /*public Color Color 
        {
            get { return _color;}
            set { _color = value;}
        }*/
        public double XFrom
        {
            get { return xfrom; }
            set { xfrom = value; }
        }

        public double XTo
        {
            get { return xto; }
            set { xto = value; }
        }

        public double YFrom
        {
            get { return yfrom; }
            set { yfrom = value; }
        }

        public double YTo
        {
            get { return yto; }
            set { yto = value; }
        }
        public bool Legend
        {
            get { return legend; }
            set { legend = value; }
        }

        public bool Autoscale
        {
            get { return autoscale; }
            set { autoscale = value; }
        }

        public bool XRange
        {
            get { return xrange; }
            set { xrange = value; }
        }
        public bool YRange
        {
            get { return yrange; }
            set { yrange = value; }
        }
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string XTitle
        {
            get { return _xTitle; }
            set { _xTitle = value; }
        }

        public string YTitle 
        {
            get { return _yTitle; }
            set { _yTitle = value; } 
        }

        public string Title 
        {
            get { return _title; }
            set { _title = value; }
        }

        public DrawType DrawType 
        {
            get { return _drawType; }
            set { _drawType = value; }
        }

        public Plot()
        {
            _drawType = global::Plot.DrawType.Lines;
            _color = "000000";
            legend = false;
            autoscale = true;
            xrange = false;
            yrange = false;
        }
        private string _GetParam()
        {
            AwokeKnowing.GnuplotCSharp.GnuPlot.Set("xlabel \"" + _xTitle + "\"");
            AwokeKnowing.GnuplotCSharp.GnuPlot.Set("ylabel \"" + _yTitle + "\"");
            string par = "using 1:2 title \"" + _title + "\"";
            switch (_drawType)
            {
                case DrawType.Lines:
                    par += " with lines";
                    break;
                case DrawType.Points:
                    par += " with points";
                    break;
                default:
                    break;
            }
            
            //par += " linecolor rgb \"#" + _color + "\"";
            return par;
        }
        public void DrawFile(string filePath)
        {
            Console.WriteLine("Start draw file \"" + filePath + "\"");
            AwokeKnowing.GnuplotCSharp.GnuPlot.Plot("\"" + filePath + "\"", _GetParam());
            Console.WriteLine("End draw file \"" + filePath + "\"");
        }

        private string _GetParam(string title)
        {
            string par = "using 1:2 ";
            if (legend)
                par += "title \"" + title + "\"";
            else
                par += "notitle";
            switch (_drawType)
            {
                case DrawType.Lines:
                    par += " with lines";
                    break;
                case DrawType.Points:
                    par += " with points";
                    break;
                default:
                    break;
            }

            //par += " linecolor rgb \"#" + _color + "\"";
            return par;
        }

        private string _GetParam(string title, int lw, int col)
        {
            string par = "using 1:2 ";
            if (legend)
                par += "title \"" + title + "\"";
            else
                par += "notitle";
            switch (_drawType)
            {
                case DrawType.Lines:
                    par += " with lines";
                    break;
                case DrawType.Points:
                    par += " with points";
                    break;
                default:
                    break;
            }

            par += " linecolor rgb \"#" + (col & 0xffffff).ToString("X") + "\"";
            par += " lw " + lw + " ";
            return par;
        }
        public void DrawFiles(ArrayList filePath, ArrayList titles)
        {
            AwokeKnowing.GnuplotCSharp.GnuPlot.Set("xlabel \"" + _xTitle + "\"");
            AwokeKnowing.GnuplotCSharp.GnuPlot.Set("ylabel \"" + _yTitle + "\"");
            if(autoscale == true)
                AwokeKnowing.GnuplotCSharp.GnuPlot.Set("autoscale");
            if(xrange == true)
                AwokeKnowing.GnuplotCSharp.GnuPlot.Set("xrange [" + xfrom.ToString().Replace(',', '.') + ":" + xto.ToString().Replace(',', '.') + "]");
            if (yrange == true)
                AwokeKnowing.GnuplotCSharp.GnuPlot.Set("yrange [" + yfrom.ToString().Replace(',', '.') + ":" + yto.ToString().Replace(',', '.') + "]");
            Console.WriteLine("Start draw file \"" + filePath + "\"");
            ArrayList param = new ArrayList();
            foreach(string s in titles)
            {
                param.Add(_GetParam(s));
            }
            AwokeKnowing.GnuplotCSharp.GnuPlot.Plots(filePath, param);
            Console.WriteLine("End draw file \"" + filePath + "\"");
        }

        public void DrawFiles(ArrayList filePath, ArrayList titles, ArrayList lw, ArrayList col)
        {
            AwokeKnowing.GnuplotCSharp.GnuPlot.Set("xlabel \"" + _xTitle + "\"");
            AwokeKnowing.GnuplotCSharp.GnuPlot.Set("ylabel \"" + _yTitle + "\"");
            if (autoscale == true)
                AwokeKnowing.GnuplotCSharp.GnuPlot.Set("autoscale");
            if (xrange == true)
                AwokeKnowing.GnuplotCSharp.GnuPlot.Set("xrange [" + xfrom.ToString().Replace(',', '.') + ":" + xto.ToString().Replace(',', '.') + "]");
            if (yrange == true)
                AwokeKnowing.GnuplotCSharp.GnuPlot.Set("yrange [" + yfrom.ToString().Replace(',', '.') + ":" + yto.ToString().Replace(',', '.') + "]");
            Console.WriteLine("Start draw file \"" + filePath + "\"");
            ArrayList param = new ArrayList();
            int i = 0;
            foreach (string s in titles)
            {
                param.Add(_GetParam(s, (int)lw[i], (int)col[i]));
                i++;
            }
            AwokeKnowing.GnuplotCSharp.GnuPlot.Plots(filePath, param);
            Console.WriteLine("End draw file \"" + filePath + "\"");
        }

        public void Close()
        {
            AwokeKnowing.GnuplotCSharp.GnuPlot.Close();
        }

        public void DrawPoints(IEnumerable<Point> points)
        {
            ArrayList arrPoints = new ArrayList();
            foreach (Point i in points)
            {
                arrPoints.Add(i);
            }
            var x = new double[arrPoints.Count];
            var y = new double[arrPoints.Count];
            for(int i = 0; i < arrPoints.Count; ++i)
            {
                x[i] = ((Point)(arrPoints[i])).X;
                y[i] = ((Point)(arrPoints[i])).Y;
            }
            AwokeKnowing.GnuplotCSharp.GnuPlot.Plot(x, y, _GetParam());
        }
    }
}
