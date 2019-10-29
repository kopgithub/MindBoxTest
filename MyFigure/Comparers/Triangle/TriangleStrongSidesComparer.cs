using MyFigure.Helpers;
using System;

namespace MyFigure.Comparers
{
    /// <summary>
    /// Сравнивает треугольники по их длинам их сторон C учетом их порядка A-B-C
    /// </summary>
    internal class TriangleStrongSidesComparer : TriangleComparer
    {
        public override bool Equals(Triangle x, Triangle y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return x.A == y.A && x.B == y.B && x.C == y.C;
        }

        public override int GetHashCode(Triangle obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "Value can`t be null");

            return HashHelper.RSHash(obj.A, obj.B, obj.C);
        }
    }
}
