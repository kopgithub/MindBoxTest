using System;

namespace MyFigure
{
    /// <summary>
    /// Фигура - Круг
    /// </summary>
    public class Circle : Figure, IEquatable<Circle>
    {
        #region Ctor

        /// <summary>
        /// Конструктор круга
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(radius), "Радиус должен быть больше 0.");

            Radius = radius;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Радиус круга
        /// делаем круг не изменяемым типом т.к. он ссылочный и хэш код зависит от радиуса
        /// </summary>
        public double Radius { get; private set; }

        /// <summary>
        /// Диаметр круга D = 2 * R
        /// </summary>
        public double Diameter => 2 * Radius;

        /// <summary>
        /// Площадь круга S = Pi * R^2
        /// </summary>
        public override double Square => Math.PI * Radius * Radius;

        /// <summary>
        /// Периметр круга P = 2*Pi*R = Pi*D
        /// </summary>
        public override double Perimeter => Math.PI * Diameter;

        #endregion

        #region ICloneable

        /// <summary>
        /// Создает копию текущего круга
        /// </summary>
        public override object Clone() => new Circle(Radius);

        #endregion

        #region IEquatable

        /// <summary>
        /// Определяет равенство текущего круга с указанным по радиусу
        /// </summary>
        public override bool Equals(object obj) => Equals(obj as Circle);

        /// <summary>
        /// Определяет равенство текущего круга с указанным по радиусу
        /// </summary>
        public bool Equals(Circle other)
            => other != null && Radius.Equals(other.Radius);

        /// <summary>
        /// Возвращает хэш код для текущего экзепляра круга
        /// </summary>
        public override int GetHashCode() => Radius.GetHashCode();

        #endregion

        protected override string ParamsInfo => $"{Radius}";
    }
}
