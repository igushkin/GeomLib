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
    /// Тест на корректную площадь многоугольника с отрицательными координатами.
    /// </summary>
    [TestMethod]
    public void CalculateArea_NegativeCoordinates_ReturnsCorrectArea()
    {
        PointF[] points = [new PointF(-3, -1), new PointF(1, -1), new PointF(1, 2), new PointF(-3, 2)];

        var polygon = new SimplePolygon(points);

        var expectedArea = 12.0; // Прямоугольник: ширина (4) * высота (3)
        Assert.AreEqual(expectedArea, polygon.calculateArea(), Constants.epsilon); ;
    }

    /// <summary>
    /// Тест на некорректную инициализацию с null-значением.
    /// </summary>
    [TestMethod]
    public void Constructor_NullPoints_ThrowsArgumentNullException()
    {
        Assert.ThrowsException<NullReferenceException>(() => new SimplePolygon(null));
    }

    /// <summary>
    /// Тест на корректную площадь многоугольника с дробными координатами.
    /// </summary>
    [TestMethod]
    public void CalculateArea_FractionalCoordinates_ReturnsCorrectArea()
    {
        PointF[] points = [new PointF(0.5f, 0.5f), new PointF(3.5f, 0.5f), new PointF(3.5f, 2.5f), new PointF(0.5f, 2.5f)];
        var polygon = new SimplePolygon(points);

        var expectedArea = 6.0; // Прямоугольник: ширина (3) * высота (2)
        Assert.AreEqual(expectedArea, polygon.calculateArea(), Constants.epsilon);
    }
}