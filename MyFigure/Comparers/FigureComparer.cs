using System;
using System.Collections;
using System.Collections.Generic;

namespace MyFigure.Comparers
{
    /// <summary>
    /// Компарер для фигур по-умолчанию.
    /// </summary>
    public class FigureComparer : IComparer, IComparer<Figure>
    {
        public static FigureComparer Default = new FigureComparer();

        protected FigureComparer()
        { }

        public int Compare(object x, object y)
        { 
            return x is Figure && y is Figure
                ? Compare((Figure)x, (Figure)y)
                : Comparer.Default.Compare(x, y);
        }

        /// <summary>
        /// Сравнивает 2 фигуры по возрастанию их площадей
        /// </summary>
        public virtual int Compare(Figure x, Figure y)
        {
            if (ReferenceEquals(x, y))
                return 0;
            else if (x == null) // nulls last
                return -1;
            else if (y == null)
                return 1;

            return x.Square.CompareTo(y.Square);
        }
    }
}
