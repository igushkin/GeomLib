using System.Drawing;

/// <summary>
/// Класс для работы с треугольниками.
/// Наследуется от <see cref="SimplePolygon"/> и добавляет специфичные методы для работы с треугольниками.
/// Поддерживает проверку, является ли треугольник прямоугольным.
/// </summary>
public class Triangle : SimplePolygon
{

    /// <summary>
    /// Конструктор класса Triangle. 
    /// Создет треугольник по трем сторонам.
    /// </summary>
    /// <param name="a">Длина стороны AB треугольника.</param>
    /// <param name="b">Длина стороны BC треугольника.</param>
    /// <param name="c">Длина стороны CA треугольника.</param>
    /// <exception cref="ArgumentException">Выбрасывается, если стороны не образуют треугольник.</exception>
    public Triangle(float a, float b, float c) : base(createPath(a,b,c)) {
    }

    /// <summary>
    /// Создает координаты вершин треугольника на основании длин его сторон.
    /// </summary>
    /// <param name="a">Длина стороны AB треугольника.</param>
    /// <param name="b">Длина стороны BC треугольника.</param>
    /// <param name="c">Длина стороны CA треугольника.</param>
    /// <returns>Массив из трех точек, представляющих вершины треугольника.</returns>
    /// <exception cref="ArgumentException">Выбрасывается, если стороны не образуют треугольник.</exception>
    private static PointF[] createPath(float a, float b, float c)
    {
        // Вычисляем координаты третьей точки (C).
        var x = (b * b + a * a - c * c) / (2.0f * a);
        var y = (float)Math.Sqrt(b * b - x * x);

        // Проверяем, образуют ли стороны треугольник
        if (float.IsNaN(y)) throw new ArgumentException("The sides do not form a triangle.");

        // Возвращаем список координат 3 вершин треугольника.
        return [new PointF(0, 0), new PointF(a, 0), new PointF(x, y)];
    }

    /// <summary>
    /// Проверяет, является ли треугольник прямоугольным.
    /// </summary>
    /// <returns></returns>
    public bool isRectangular()
    {
        // Координаты вершин треугольника.
        float x1 = points[0].X, x2 = points[1].X, x3 = points[2].X;
        float y1 = points[0].Y, y2 = points[1].Y, y3 = points[2].Y;

        // Квадраты длин сторон.
        var a = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
        var b = (x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2);
        var c = (x1 - x3) * (x1 - x3) + (y1 - y3) * (y1 - y3);

        // Проверяем условие теоремы Пифагора с учетом погрешности (epsilon).
        return Math.Abs(a - b - c) < Constants.epsilon ||
            Math.Abs(b - a - c) < Constants.epsilon ||
            Math.Abs(c - a - b) < Constants.epsilon;
    }
}
