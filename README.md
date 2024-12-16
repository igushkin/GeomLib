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

## **Задание**

В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

## **SQL Scheme**

Создадим таблицы базы данных

```sql
CREATE TABLE category (
  id INT PRIMARY KEY,
  name VARCHAR(100)
);

CREATE TABLE product (
  id INT PRIMARY KEY,
  name VARCHAR(100)
);

CREATE TABLE product_category ( 
    product_id INT, 
    category_id INT, 
    PRIMARY KEY (product_id, category_id), 
    FOREIGN KEY (product_id) REFERENCES product(id), 
    FOREIGN KEY (category_id) REFERENCES category(id) 
); 

INSERT INTO category VALUES (1, 'Food');
INSERT INTO category VALUES (2, 'Electronic devices');

INSERT INTO product VALUES (1, 'Milk');
INSERT INTO product VALUES (2, 'Pineapples');
INSERT INTO product VALUES (3, 'Apple iPhone 15');
INSERT INTO product VALUES (4, 'Squeegee');

INSERT INTO product_category VALUES (1, 1);
INSERT INTO product_category VALUES (2, 1);
INSERT INTO product_category VALUES (3, 2);
```

![image](https://github.com/user-attachments/assets/fac9a3af-e18c-46ba-b8a9-2064441889a1)


## **Пишем SQL запрос для извлечения данных**

```sql
SELECT p.name as product_name, c.name as category_name
FROM product_category AS pc
	LEFT JOIN category AS c on c.id = pc.category_id
	RIGHT JOIN product AS p ON p.id = pc.product_id;
```
## **Результат**

![image](https://github.com/user-attachments/assets/1be468ed-36aa-43aa-a2d1-5063b8fe60c9)
