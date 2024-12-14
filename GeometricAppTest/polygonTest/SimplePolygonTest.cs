using System.Drawing;

namespace TestProject1.polygonTest;

[TestClass]
public class SimplePolygonTest
{
    /// <summary>
    /// Тест на выброс исключения при передаче массива с количеством вершин менее трех.
    /// </summary>
    [TestMethod]
    public void Constructor_LessThanThreePoints_ThrowsArgumentException()
    {
        var points = new PointF[] { new PointF(0, 0), new PointF(4, 0) };
        Assert.ThrowsException<ArgumentException>(() => new SimplePolygon(points));
    }

    /// <summary>
    /// Тест на выброс исключения, если стороны многоугольника пересекаются.
    /// </summary>
    [TestMethod]
    public void Constructor_IntersectingEdges_ThrowsArgumentException()
    {
        var points = new PointF[] { new PointF(0, 0), new PointF(4, 0), new PointF(2, 2), new PointF(2, -2) };
        Assert.ThrowsException<ArgumentException>(() => new SimplePolygon(points));
    }

    /// <summary>
    /// Тест на корректную площадь прямоугольника с отрицательными координатами.
    /// </summary>
    [TestMethod]
    [DataRow(-2, 2)]
    [DataRow(-2, -2)]
    public void CalculateArea_NegativeCoordinates_ReturnsCorrectArea(float width, float height)
    {
        PointF[] points = [new PointF(0, 0), new PointF(0, height), new PointF(width, height), new PointF(width, 0)];
        var polygon = new SimplePolygon(points);
        var expectedArea = Math.Abs(width * height);

        Assert.AreEqual(expectedArea, polygon.calculateArea(), Constants.epsilon);
    }

    /// <summary>
    /// Тест на корректную площадь прямоугольника.
    /// </summary>
    [TestMethod]
    [DataRow(2, 2)]
    [DataRow(2.5f, 1.75f)]
    [DataRow(2.5f, 0)]
    [DataRow(0, 2.5f)]
    public void CalculateArea_FractionalCoordinates_ReturnsCorrectArea(float width, float height)
    {
        PointF[] points = [new PointF(0, 0), new PointF(0, height), new PointF(width, height), new PointF(width, 0)];
        var polygon = new SimplePolygon(points);
        var expectedArea = width * height;

        Assert.AreEqual(expectedArea, polygon.calculateArea(), Constants.epsilon);
    }
}