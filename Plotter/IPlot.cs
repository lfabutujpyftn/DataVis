using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plot
{
    public enum DrawType
    {
        Points,
        Lines
    }
    /*public enum Color
    {
        Red,
        Green,
        Blue,
        Black
    }*/

    public struct Point
    {
        public double X;
        public double Y;
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    public interface IPlot
    {
       // Color Color { get; set; }

        string Color { get; set; }

        DrawType DrawType { get; set; }
        string XTitle { get; set; }
        string YTitle { get; set; }
        string Title { get; set; }
        void DrawFile(string filePath);
        void DrawPoints(IEnumerable<Point> points);
       
    }
}
