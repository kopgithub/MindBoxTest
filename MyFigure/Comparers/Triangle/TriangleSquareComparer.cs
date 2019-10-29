using System;

namespace MyFigure.Comparers
{
    /// <summary>
    /// Сравнивает треугольники по их площадям
    /// </summary>
    internal class TriangleSquareComparer : TriangleComparer
    {
        public override bool Equals(Triangle x, Triangle y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return x.Square == y.Square;
        }

        public override int GetHashCode(Triangle obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "Value can`t be null");

            return obj.Square.GetHashCode();
        }
    }
}
