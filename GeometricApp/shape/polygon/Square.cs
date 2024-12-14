using System.Drawing;

/// <summary>
/// Квадрат
/// </summary>
public class Square : SimplePolygon {
    public Square(float size) : base(scaleTo(createPath(), size, size)) { }

    private static PointF[] createPath() => [new PointF(0, 0), new PointF(0, 1), new PointF(1, 1), new PointF(1, 0)];
}
