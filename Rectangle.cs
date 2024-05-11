using System.Xml.Serialization;
using tryoutsmth;

public class Rectangle : Figure
{
    public Rectangle(int startX, int startY, int width, int height, Color outlineColor)
    {
        X = startX;
        Y = startY;
        Width = width;
        Height = height;
        OutlineColor = outlineColor;
        
    }

    
    public Rectangle()
    {

    }

    public override void Draw(Graphics g)
    {
        using (Pen pen = new Pen(OutlineColor, 5))
        {
            g.DrawRectangle(pen, X, Y, Width, Height);
        }

        
    }

    public override void Fill(Graphics g, Color fillColor)
    {
        if (IsFilled)
        {
            using (Brush brush = new SolidBrush(fillColor))
            {
                g.FillRectangle(brush, X, Y, Width, Height);
            }
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

    public override bool Contains(Point point)
    {
        return (point.X >= X && point.X <= X + Width && point.Y >= Y && point.Y <= Y + Height);
    }

    

    public override double CalculateArea()
    {
        return area = Width * Height;
    }

    public override Figure Clone()
    {
        return new Rectangle(X, Y, Width, Height, OutlineColor);
    }

}