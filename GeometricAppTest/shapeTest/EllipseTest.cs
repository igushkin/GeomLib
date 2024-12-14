namespace TestProject1.shapeTest
{
    [TestClass]
    public class EllipseTest
    {
        [TestMethod]
        [DataRow(3, 5)]
        public void GetArea_ValidEllipse_ShouldReturnCorrectArea(float rx, float ry)
        {
            var ellipse = new Ellipse(rx, ry);
            var actualArea = ellipse.calculateArea();
            var expectedArea = Math.PI * rx * ry;

            Assert.AreEqual(expectedArea, actualArea, Constants.epsilon);
        }

        [TestMethod]
        [DataRow(3)]
        public void GetArea_ValidCircle_ShouldReturnCorrectArea(float r)
        {
            var circle = new Circle(r);
            var actualArea = circle.calculateArea();
            var expectedArea = Math.PI * r * r;

            Assert.AreEqual(expectedArea, actualArea, Constants.epsilon);
        }
    }
}