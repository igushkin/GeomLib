using System.Drawing;

/// <summary>
/// Прямоугольник
/// </summary>
public class Rectangle : SimplePolygon
{
    public Rectangle(float width, float height) : base(scaleTo(createPath(), width, height)) { }

    private static PointF[] createPath() => [new PointF(0, 0), new PointF(0, 1), new PointF(1, 1), new PointF(1, 0)];
}
