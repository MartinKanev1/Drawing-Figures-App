using System;
using System.Drawing;

namespace tryoutsmth
{
    public class Square : Figure
    {
        public Square(int startX, int startY, int sideLength, Color outlineColor)
        {
            X = startX;
            Y = startY;
            Width = sideLength;
            Height = sideLength;
            OutlineColor = outlineColor;
        }

        public Square() { }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(OutlineColor, 5))
            {
                g.DrawRectangle(pen, X, Y, Width, Height);
            }
            
        }

        public override void Fill(Graphics g, Color fillColor)
        {
            using (Brush brush = new SolidBrush(fillColor))
            {
                g.FillRectangle(brush, X, Y, Width, Height);
            }
        }

        public override void SetDimensions(Point startPoint, Point endPoint)
        {
            X = Math.Min(startPoint.X, endPoint.X);
            Y = Math.Min(startPoint.Y, endPoint.Y);
            int sideLength = Math.Min(Math.Abs(startPoint.X - endPoint.X), Math.Abs(startPoint.Y - endPoint.Y));
            Width = sideLength;
            Height = sideLength;
            CalculateArea();
        }

        public override double CalculateArea()
        {
            return area = Width * Width;
        }

        
        public override bool Contains(Point point)
        {
            return (point.X >= X && point.X <= X + Width && point.Y >= Y && point.Y <= Y + Height);
        }
        

       
        

        public override Figure Clone()
        {
            return new Square(X, Y, Width, OutlineColor);
        }
    }
}
