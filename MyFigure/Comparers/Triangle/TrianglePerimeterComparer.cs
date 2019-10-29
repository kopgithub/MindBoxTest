using System;

namespace MyFigure.Comparers
{
    /// <summary>
    /// Сравнивает треугольники по длинне их периметров
    /// </summary>
    internal class TrianglePerimeterComparer : TriangleComparer
    {
        public override bool Equals(Triangle x, Triangle y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return x.Perimeter == y.Perimeter;
        }

        public override int GetHashCode(Triangle obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "Value can`t be null");

            return obj.Perimeter.GetHashCode();
        }
    }
}
