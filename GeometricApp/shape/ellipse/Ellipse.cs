// See https://aka.ms/new-console-template for more information
public class Ellipse : IShape
{
    private readonly double radiusX;
    private readonly double radiusY;

    public Ellipse(double radiusX, double radiusY) { 
        this.radiusX = radiusX;
        this.radiusY = radiusY;
    }

    public double calculateArea()
    {
        return Math.PI * radiusX * radiusY;
    }
}
