using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tryoutsmth
{
    public class Ellipse : Figure
    {
        public Ellipse(int startX, int startY, int width, int height, Color outline)
        {
            X = startX;
            Y = startY;
            Width = width;
            Height = height;
            OutlineColor = outline;
        }

        public Ellipse() { }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(OutlineColor, 5))
            {
                g.DrawEllipse(pen, X, Y, Width, Height);
            }
            
        }

        public override void Fill(Graphics g, Color fillColor)
        {
            using (Brush brush = new SolidBrush(FillColor))
            {
                g.FillEllipse(brush, X, Y, Width, Height);
            }
        }

        public override void SetDimensions(Point startPoint, Point endPoint)
        {


            X = Math.Min(startPoint.X, endPoint.X);
            Y = Math.Min(startPoint.Y, endPoint.Y);
            Width = Math.Abs(startPoint.X - endPoint.X);
            Height = Math.Abs(startPoint.Y - endPoint.Y);

            CalculateArea();
        }

        public override double CalculateArea()
        {

            double a = Width / 2.0;
            double b = Height / 2.0;
            return area = Math.PI * a * b;
        }

        public override bool Contains(Point point)
        {
            double centerX = X + Width / 2.0;
            double centerY = Y + Height / 2.0;
            double radiusX = Width / 2.0;
            double radiusY = Height / 2.0;

            double dx = (point.X - centerX) / radiusX;
            double dy = (point.Y - centerY) / radiusY;

            return dx * dx + dy * dy <= 1;
        }

       

        public override Figure Clone()
        {
            return new Ellipse(X, Y, Width, Height,  OutlineColor);
        }

    }



}
