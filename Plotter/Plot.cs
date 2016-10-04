using System;
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
        /*public Color Color 
        {
            get { return _color;}
            set { _color = value;}
        }*/

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
            
            par += " linecolor rgb \"#" + _color + "\"";
            return par;
        }
        public void DrawFile(string filePath)
        {
            Console.WriteLine("Start draw file \"" + filePath + "\"");
            AwokeKnowing.GnuplotCSharp.GnuPlot.Plot("\"" + filePath + "\"", _GetParam());
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
