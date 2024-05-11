using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tryoutsmth
{
    public abstract class Figure
    {

        public Figure()
        {
            
        }
        public int X { set; get; }
        public int Y { set; get; }
        public int Width { set; get; }
        public int Height { set; get; }
        public Color OutlineColor { set; get; }
        public Color FillColor { get; set; }
        public bool IsFilled { get; set; }
       

        public double area { set; get; }
        public abstract void Draw(Graphics g);
        public abstract void Fill(Graphics g, Color fillColor);
        public abstract void SetDimensions(Point startPoint, Point endPoint);
        public abstract bool Contains(Point point);

        public abstract double CalculateArea();

        public abstract Figure Clone();
    }
}
