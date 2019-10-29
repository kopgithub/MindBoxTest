using System;
using System.Collections;
using System.Collections.Generic;

namespace MyFigure.Comparers
{
    /// <summary>
    /// Базовый класс, задающий разные варианты равенства треугольников
    /// </summary>
    public abstract class TriangleComparer : FigureComparer, IEqualityComparer, IEqualityComparer<Triangle>
    {
        #region TriangleComparer`s

        /// <summary>
        /// Сравнивает треугольники по их длинам их сторон БЕЗ учета их порядка A-B-C
        /// </summary>
        public static TriangleComparer Sides => new TriangleSidesComparer();

        /// <summary>
        /// Сравнивает треугольники по их длинам их сторон C учетом их порядка A-B-C
        /// </summary>
        public static TriangleComparer StrongSides => new TriangleStrongSidesComparer();

        /// <summary>
        /// Сравнивает треугольники по длинне их периметров
        /// </summary>
        public static TriangleComparer Perimeter => new TrianglePerimeterComparer();

        /// <summary>
        /// Сравнивает треугольники по их площадям
        /// </summary>
        public static TriangleComparer Square => new TriangleSquareComparer();

        #endregion

        public new bool Equals(object x, object y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null || x.GetType() != y.GetType())
                return false;

            return x is Triangle 
                ? Equals((Triangle)x, (Triangle)y) 
                : x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "Value can`t be null");

            return obj is Triangle 
                ? GetHashCode((Triangle)obj)
                : obj.GetHashCode();
        }

        public abstract bool Equals(Triangle x, Triangle y);

        public abstract int GetHashCode(Triangle obj);
    }
}
