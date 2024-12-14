using System.Drawing;

/// <summary>
/// Класс для работы с многоугольниками.
/// Позволяет вычислять площадь многоугольников с использованием алгоритма Гаусса (Shoelace formula).
/// Также проверяет корректность многоугольника, включая отсутствие самопересечений.
/// Многоугольник задается в виде набора точек, переданных в порядке обхода.
/// </summary>
public class SimplePolygon : IShape
{
    /// <summary>
    /// Массив точек (вершин) многоугольника. 
    /// </summary>
    protected readonly PointF[] points;

    /// <summary>
    /// Конструктор класса SimplePolygon.
    /// Проверяет корректность многоугольника, включая наличие хотя бы трех точек и отсутствие пересечений сторон.
    /// </summary>
    /// <param name="points">Массив вершин многоугольника.</param>
    /// <exception cref="ArgumentException">Выбрасывается ArgumentException, если количество точек меньше 3 или отрезки пересекаются между собой.</exception>
    public SimplePolygon(PointF[] points)
    {
        if (!isPolygonValid(points))
            throw new ArgumentException("Кол-во вершин в многоугольнике должно быть >= 3 и стороны не должен пересекаться.");
        this.points = points;
    }

    /// <summary>
    /// Вычисляет площадь многоугольника используя алгоритм Шнурков (Shoelace formula) - https://en.wikipedia.org/wiki/Shoelace_formula.
    /// Временная сложность алгоритмы O(n), где n - кол-во вершин.
    /// </summary>
    /// <returns>Площадь многоугольника</returns>
    public double calculateArea()
    {
        var area = 0.0;

        for (var i = 0; i < points.Length; i++)
        {
            var pointA = points[i];
            var poitnB = points[(i + 1) % points.Length];
            area += pointA.X * poitnB.Y - poitnB.X * pointA.Y;
        }

        return Math.Abs(area / 2);
    }

    /// <summary>
    /// Проверяет корректность многоугольника. 
    /// Условия корректности:
    /// - Минимальное количество вершин — 3. 
    /// - Отсутствие пересечений между любыми сторонами.
    /// </summary>
    /// <param name="points">Массив вершин</param>
    /// <returns>True, если многоугольник корректен, иначе False</returns>
    private bool isPolygonValid(PointF[] points) => points.Length > 2 && !hasIntersection(points);

    /// <summary>
    /// Проверяет наличие пересечений между любыми сторонами многоугольника.
    /// Метод работает за O(n^2), где n — количество вершин. 
    /// При больших входных данных можно использовать алгоритм Бентли-Оттманна, которые работает за (O(n * log(n))).
    /// </summary>
    /// <param name="points">Массив вершин</param>
    /// <returns>True, если есть пересения, иначе False</returns>
    private bool hasIntersection(PointF[] points)
    {
        for (var i = 0; i < points.Length - 1; i++)
        {
            for (var j = 0; j < points.Length - 1; j++)
            {
                if (i == j) continue;
                if (doIntersect(points[i], points[i + 1], points[j], points[j + 1])) return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Проверяет, пересекаются ли два отрезка, заданные точками. 
    /// Метод основан на вычислении направления (ориентации точек) и проверке принадлежности точек отрезкам.
    /// Алгоритм описан в книге Алгоритмы. Построение и анализ. Кормен Т. Раздел - Вычислительная Геометрия.
    /// </summary>
    /// <param name="p1">Начальная точка первого отрезка.</param>
    /// <param name="p2">Конечная точка первого отрезка.</param>
    /// <param name="p3">Начальная точка второго отрезка.</param>
    /// <param name="p4">Конечная точка второго отрезка.</param>
    /// <returns>True, если есть пересения, иначе False</returns>
    private bool doIntersect(PointF p1, PointF p2, PointF p3, PointF p4)
    {
        var d1 = getDirection(p3, p4, p1);
        var d2 = getDirection(p3, p4, p2);
        var d3 = getDirection(p1, p2, p3);
        var d4 = getDirection(p1, p2, p4);

        if (((d1 > 0 && d2 < 0) || (d1 < 0 && d2 > 0)) && ((d3 > 0 && d4 < 0) || (d3 < 0 && d4 > 0)))
            return true;
        else if (d1 == 0 && onSegment(p3, p4, p1))
            return true;
        else if (d2 == 0 && onSegment(p3, p4, p2))
            return true;
        else if (d3 == 0 && onSegment(p1, p2, p3))
            return true;
        else if (d4 == 0 && onSegment(p1, p2, p4))
            return true;

        return false;
    }

    /// <summary>
    /// Вычисляет направление векторного произведения для трех точек. 
    /// Знак результата указывает на относительное положение точки p3 относительно вектора p1->p2.
    /// </summary>
    /// <param name="p1">Начальная точка вектора.</param>
    /// <param name="p2">Конечная точка вектора.</param>
    /// <param name="p3">Точка для проверки направления.</param>
    /// <returns>
    /// Положительное значение, если точка p3 лежит слева от вектора p1->p2.
    /// Отрицательное значение, если справа.
    /// Ноль, если точки коллинеарны.
    /// </returns>
    private float getDirection(PointF p1, PointF p2, PointF p3) => (p3.X - p1.X) * (p2.Y - p1.Y) - (p2.X - p1.X) * (p3.Y - p1.Y);

    /// <summary>
    /// Если векторы коллинеарны. Определяет лежит ли точка непостредственно на самом отрезке.
    /// </summary>
    /// <param name="p1">Начальная точка вектора</param>
    /// <param name="p2">Конечная точка вектора</param>
    /// <param name="p3">Проверяемая точка</param>
    /// <returns>True, False</returns>
    private bool onSegment(PointF p1, PointF p2, PointF p3)
    {
        if (Math.Abs(p3.X - p1.X) <= float.Epsilon) return Math.Min(p1.Y, p2.Y) < p3.Y && p3.Y < Math.Max(p1.Y, p2.Y);
        else if (Math.Abs(p3.Y - p1.Y) <= float.Epsilon) return Math.Min(p1.X, p2.X) < p3.X && p3.X < Math.Max(p1.X, p2.X);
        return false;
    }

    /// <summary>
    /// Масштабирует координаты вершин многоугольника по заданным коэффициентам. 
    /// </summary>
    /// <param name="points">Массив вершин многоугольника</param>
    /// <param name="widthFactor">Коэффициент масштабирования по ширине</param>
    /// <param name="heightFactor">Коэффициент масштабирования по высоте</param>
    /// <returns>Новый массив точек с масштабированными координатами</returns>
    protected static PointF[] scaleTo(PointF[] points, float widthFactor, float heightFactor) => 
        points.Select(p => new PointF(p.X * widthFactor, p.Y * heightFactor)).ToArray();
}