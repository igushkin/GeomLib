using System.Drawing;

/// <summary>
/// Шестиугольник
/// </summary>
public class Hexagon : SimplePolygon {
    public Hexagon(float width, float height) : base(scaleTo(createPath(), width, height)) { }

    private static PointF[] createPath() => Enumerable.Range(0, 6)
        .Select(i => i * 60)
        .Select(angle => new PointF(
            (float)(0.5 + Math.Cos(angle * Math.PI / 180) * 0.5),
            (float)(0.5 + Math.Sin(angle * Math.PI / 180) * 0.5)))
        .ToArray();
}
