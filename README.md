# **1. GeometricLibrary**

## **Описание**

Библиотека предназначена для вычисления площади геометрических фигур. Основной функционал:

- Вычисление площади круга по радиусу.
- Вычисление площади многоугольников, включая треугольники, используя метод Гаусса.
- Проверка треугольника на прямоугольность.

## **Пример использования**

```csharp
using System;

// Вычисление площади фигур
var shapes = new IShape[]
{
    new Circle(5),                // Круг с радиусом 5
    new Triangle(3, 4, 5),        // Треугольник со сторонами 3, 4, 5
};

foreach (var shape in shapes)
{
    Console.WriteLine($"Тип фигуры: {shape.GetType().Name}, Площадь: {shape.calculateArea()}");
}

// Проверка прямоугольного треугольника
var triangle = new Triangle(3, 4, 5);
Console.WriteLine($"Является прямоугольным: {triangle.isRectangular()}"); // true
```

# **2. MS SQL запрос**

В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

```sql
SELECT product.name as product_name, product_category.name as product_category
FROM product
LEFT JOIN product_category ON product.category_id = product_category.id
ORDER BY product_name;
```
