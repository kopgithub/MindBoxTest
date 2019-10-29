using MyFigure;
using MyFigure.Comparers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UsingFigure
{
    /// <summary>
    /// Проверка наших трудов...
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = Console.LargestWindowHeight - 11;

            // проверяем методы сравнение и вычисление хэш кодов треугольников
            // экземпляры равны - хеш коды равны!
            var t1 = new Triangle(1, 2, 3);
            var t2 = new Triangle(3, 1, 2);
            Console.WriteLine($"{t1.Equals(t2)} {t1.GetHashCode()} {t2.GetHashCode()}");
            Console.WriteLine();
            
            var figures = new Figure[] {
                new Circle(12),
                new Triangle(5, 7, 9),
                new Rectangle(11, 2),
                new Circle(7),
                new Triangle(7, 5, 9),
                new Rectangle(2, 11),
                new Circle(31),
                new Rectangle(5, 7),
                new Triangle(3, 4, 5),
                new Circle(12),
                new Triangle(6, 6, 6),
                new Rectangle(5, 7),
                new Rectangle(4, 4),
            };

            // выводим параметры всех фигур
            foreach (var f in figures)
            {
                var addInfo = string.Empty;
                if (f is Triangle t)
                {
                    if (t.IsEquilateral)
                        addInfo += "Equilateral";
                    else if (t.IsRectangular)
                        addInfo += "Rectangular";
                }

                if (f is Rectangle r && r.IsSquare)
                    addInfo += "Square";

                Console.WriteLine($"{f} {addInfo}");
            }
            Console.WriteLine();

            // ищем равные фигуры
            for (int i = 0; i < figures.Length - 1; i++)
            {
                for (int j = i + 1; j < figures.Length; j++)
                {
                    var f1 = figures[i];
                    var f2 = figures[j];
                    if (f1.Equals(f2))
                        Console.WriteLine($"[{i}]{f1} = [{j}]{f2}");
                }
            }
            Console.WriteLine();

            // выводим отсортированные по ПЛОЩАДИ фигуры по типам, через IComparable
            Console.WriteLine("Sorting with IComparable by types");
            foreach (var t in figures.Select(f => f.GetType()).Distinct())
            {
                var figuresT = figures
                    .Where(f => f.GetType().Equals(t))
                    .ToArray();
                Array.Sort(figuresT);
                foreach (var f in figuresT)
                    Console.WriteLine($"{f}");
            }
            Console.WriteLine();

            // Сквозная сортировка разных фигур по ПЛОЩАДИ, через IComparable
            Console.WriteLine("Sorting with IComparable all figures");
            Array.Sort(figures);
            foreach (var f in figures)
                Console.WriteLine($"{f}");
            Console.WriteLine();

            // Теперь для треугольников у нас есть разные варианты их сравнения
            // которые можно использовать например, при работе с хэш таблицами
            var eq = TriangleComparer.StrongSides;
            // var eq = TriangleComparer.Sides; // в этом случае получим эксепшен, т.к. с этой точки зрения у нас есть одинаковые треугольники
            // var eq = TriangleComparer.Square; // в этом случае получим эксепшен, т.к. с этой точки зрения у нас есть одинаковые треугольники
            // var eq = TriangleComparer.Perimeter; // в этом случае получим эксепшен, т.к. с этой точки зрения у нас есть одинаковые треугольники
            var dic = new Dictionary<Triangle, string>(eq);
            foreach (var t in figures.OfType<Triangle>())
                dic.Add(t, t.ToString());
            Console.WriteLine($"{dic.Count} triangles was added to Dictionary");
            Console.WriteLine();

            Console.WriteLine("Press any key to Exit.");
            Console.ReadKey();
        }
    }
}
