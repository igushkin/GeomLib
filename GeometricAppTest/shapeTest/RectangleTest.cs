namespace TestProject1.shapeTest;

[TestClass]
public class RectangleTest
{
    [TestMethod]
    [DataRow(6, 7)]
    [DataRow(3, 5)]
    public void RectangleAreaTest(float width, float height)
    {
        var rectangle = new Rectangle(width, height);
        var actualArea = rectangle.calculateArea();
        var expectedArea = width * height;

        Assert.AreEqual(expectedArea, actualArea, Constants.epsilon);
    }

    [TestMethod]
    [DataRow(6)]
    [DataRow(3)]
    public void SquareAreaTest(float size)
    {
        var square = new Square(size);
        var actualArea = square.calculateArea();
        var expectedArea = size * size;

        Assert.AreEqual(expectedArea, actualArea, Constants.epsilon);
    }
}
