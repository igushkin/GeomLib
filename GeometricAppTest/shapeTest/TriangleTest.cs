namespace TestProject1.shapeTest;

[TestClass]
public class TriangleTest
{
    [TestMethod]
    [DataRow(3, 4, 5)] // Прямоугольный треугольник
    [DataRow(6, 8, 10)] // Прямоугольный треугольник
    [DataRow(7, 8, 9)] // Обычный треугольник
    public void GetArea_ValidTriangle_ShouldReturnCorrectArea(float a, float b, float c)
    {
        var triangle = new Triangle(a, b, c);
        var s = (a + b + c) / 2;
        var expectedArea = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        Assert.AreEqual(expectedArea, triangle.calculateArea(), Constants.epsilon);
    }

    [TestMethod]
    [DataRow(3, 4, 5, true)] // Прямоугольный треугольник
    [DataRow(6, 8, 10, true)] // Прямоугольный треугольник
    [DataRow(7, 8, 9, false)] // Обычный треугольник
    public void IsRight_ValidTriangle_ShouldReturnIfRight(float a, float b, float c, bool isRight)
    {
        var triangle = new Triangle(a, b, c);
        Assert.AreEqual(isRight, triangle.isRectangular());
    }

    [TestMethod]
    [DataRow(0, 2, 3)] // Нулевая сторона
    [DataRow(1, 2, 3)] // Несоответствие неравенству треугольника
    [DataRow(10, 1, 1)] // Несоответствие неравенству треугольника
    public void Constructor_InvalidSides_ShouldThrowArgumentException(float a, float b, float c)
    {
        Assert.ThrowsException<ArgumentException>(() => new Triangle(a, b, c));
    }

    [TestMethod]
    [DataRow(-1, 1, 1)]
    [DataRow(-1, -1, 1)]
    [DataRow(-1, -1, -1)]
    [DataRow(-1.99f, 1, 1)]
    public void GetArea_ZeroOrNegativeSides_ShouldReturnCorrectArea(float a, float b, float c)
    {
        var triangle = new Triangle(a, b, c);
        var s = (a + b + c) / 2;
        var expectedArea = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        Assert.AreEqual(expectedArea, triangle.calculateArea(), Constants.epsilon);
    }

    [TestMethod]
    [DataRow(0.1f, 0.1f, 0.1f)]
    public void EdgeCase_VerySmallTriangle_ShouldWork(float a, float b, float c)
    {
        var s = (a + b + c) / 2;
        var expectedArea = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

        var triangle = new Triangle(a, b, c);

        // Assert
        Assert.AreEqual(expectedArea, triangle.calculateArea(), Constants.epsilon);
    }
}