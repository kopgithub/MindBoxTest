using MyFigure.Comparers;
using System;

namespace MyFigure
{
    /// <summary>
    /// Базовый класс для всех фигур.
    /// </summary>
    public abstract class Figure :
        IComparable, IComparable<Figure>, // все фигуры должны иметь порядок сортировки по ПЛОЩАДИ
        ICloneable // т.к. все фигуры ссылочный тип определим метод для создания копий экземпляров
    {
        /// <summary>
        /// Площадь фигуры.
        /// Любая фигура имеет площадь, вычисление которой будет реализовано в классах наследниках.
        /// </summary>
        public abstract double Square { get; }

        /// <summary>
        /// Периметр фигуры.
        /// Любая фигура имеет периметр, вычисление которого будет реализовано в классах наследниках.
        /// </summary>
        public abstract double Perimeter { get; }

        /// <summary>
        /// Создает копию текущего экземпляра
        /// </summary>
        public abstract object Clone();

        /// <summary>
        /// Определяет порядок сортировки между фигурами по их ПЛОЩАДИ
        /// </summary>
        public int CompareTo(object obj)
        {
            if (!(obj is Figure))
                throw new ArgumentException("Object must be of type Figure.");

            return CompareTo((Figure)obj);
        }

        /// <summary>
        /// Определяет порядок сортировки между фигурами по их ПЛОЩАДИ
        /// </summary>
        public virtual int CompareTo(Figure other) => FigureComparer.Default.Compare(this, other);

        /// <summary>
        /// Информация о параметрах фигуры для ToString()
        /// </summary>
        protected virtual string ParamsInfo => string.Empty;
            
        public override string ToString()
        {
            var tn = GetType().Name;
            return $"{tn}({ParamsInfo}) P={Perimeter:F} S={Square:F}";
        }
    }
}
