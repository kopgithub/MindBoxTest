using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MyFigure.Comparers
{
    /// <summary>
    /// Сравнивает треугольники по их длинам их сторон БЕЗ учета их порядка A-B-C
    /// </summary>
    internal class TriangleSidesComparer : TriangleComparer
    {
        /// <summary>
        /// Компарер для сравнения System.Double
        /// </summary>
        private EqualityComparer<double> Eq => EqualityComparer<double>.Default;

        /// <summary>
        /// Отсортированный массив с длинами сторон
        /// </summary>
        private double[] GetSortedSides(Triangle t) => new[] { t.A, t.B, t.C }
            .OrderBy(x => x)
            .ToArray();

        /// <summary>
        /// будем считать любой другой треугольник с теми же сторонами но в 
        /// другом порядке равным данному т.е. abc=bac=acb=cba 
        /// </summary>
        public override bool Equals(Triangle x, Triangle y)
        {
            if (ReferenceEquals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return ((IStructuralEquatable)GetSortedSides(x))
                .Equals(GetSortedSides(y), Eq);
        }

        public override int GetHashCode(Triangle obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "Value can`t be null");

            return ((IStructuralEquatable)GetSortedSides(obj)).GetHashCode(Eq);
        }
    }
}
