using System.Drawing;

/// <summary>
/// Трапеция
/// </summary>
public class Trapezoid : SimplePolygon
{
    public Trapezoid(float width, float height) : base(scaleTo(createPath(), width, height)) { }

    private static PointF[] createPath() => [new PointF(0, 0), new PointF(0.25f, 1), new PointF(0.75f, 1), new PointF(1, 0)];
}