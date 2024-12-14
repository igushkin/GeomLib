namespace TestProject1.shapeTest;

[TestClass]
public class TrapezoidTest
{
    [TestMethod]
    [DataRow(1, 1)]
    [DataRow(3, 7)]
    public void TrapezoidAreaTest(float width, float height)
    {
        var trapezoid = new Trapezoid(width, height);
        var actualArea = trapezoid.calculateArea();
        var expectedArea = 3f / 4 * width * height;

        Assert.AreEqual(expectedArea, actualArea, Constants.epsilon);
    }
}
