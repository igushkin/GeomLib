namespace TestProject1.shapeTest;

[TestClass]
public class HexagonTest
{
    [TestMethod]
    [DataRow(1, 1)]
    [DataRow(3, 7)]
    public void HexagonAreaTest(float width, float height)
    {
        var hexagon = new Hexagon(width, height);
        var actualArea = hexagon.calculateArea();
        var expectedArea = 3 * Math.Sqrt(3) * width * height / 8;

        Assert.AreEqual(expectedArea, actualArea, Constants.epsilon);
    }
}
