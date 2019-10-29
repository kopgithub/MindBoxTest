using MyFigure.Comparers;
using System;
using System.Linq;

namespace MyFigure
{
    /// <summary>
    /// Фигура - Треугольник
    /// </summary>
    public class Triangle : Figure, IEquatable<Triangle>
    {
        #region Ctor

        /// <summary>
        /// Конструктор треугольника.
        /// </summary>
        /// <param name="a">Сторона A</param>
        /// <param name="b">Сторона B</param>
        /// <param name="c">Сторона C</param>
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentOutOfRangeException(
                    "Все стороны треугольника должены быть больше 0.");
            
            A = a;
            B = b;
            C = c;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Сторона A
        /// делаем круг не изменяемым типом т.к. он ссылочный и хэш код зависит от сторон
        /// </summary>
        public double A { get; private set; }

        /// <summary>
        /// Сторона B
        /// делаем круг не изменяемым типом т.к. он ссылочный и хэш код зависит от сторон
        /// </summary>
        public double B { get; private set; }

        /// <summary>
        /// Сторона C
        /// делаем круг не изменяемым типом т.к. он ссылочный и хэш код зависит от сторон
        /// </summary>
        public double C { get; private set; }

        /// <summary>
        /// Площадь треугольника
        /// </summary>
        public override double Square
        {
            get
            {
                var p = Perimeter / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }

        /// <summary>
        /// Периметр треугольника
        /// </summary>
        public override double Perimeter => A + B + C;

        /// <summary>
        /// Признак что треугольник равносторонний
        /// </summary>
        public bool IsEquilateral => A == B && B == C;

        /// <summary>
        /// Признак что треугольник прямоугольный
        /// </summary>
        public bool IsRectangular
        {
            get
            {
                var x = new[] { A, B, C }.OrderBy(s => s).ToArray();
                return x[0] * x[0] + x[1] * x[1] == x[2] * x[2];
            } 
        }

        #endregion

        #region ICloneable

        /// <summary>
        /// Создает копию текущего круга
        /// </summary>
        public override object Clone() => new Triangle(A, B, C);

        #endregion

        #region IEquatable

        /// <summary>
        /// По-умолчанию сравниваем треугольники по их длинам их сторон БЕЗ учета их порядка A-B-C
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Triangle);

        /// <summary>
        /// По-умолчанию сравниваем треугольники по их длинам их сторон БЕЗ учета их порядка A-B-C
        /// </summary>
        public bool Equals(Triangle other) => TriangleComparer.Sides.Equals(this, other);

        /// <summary>
        /// Возвращает хэш код для текущего экзепляра треугольник
        /// </summary>
        public override int GetHashCode() => TriangleComparer.Sides.GetHashCode(this);

        #endregion

        protected override string ParamsInfo => $"{A}, {B}, {C}";
    }
}
