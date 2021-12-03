using System;

namespace AClosestPoint;

internal class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public double GetDistance(Point point)
    {
        double dx = point.X - X;
        double dy = point.Y - Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }
}

