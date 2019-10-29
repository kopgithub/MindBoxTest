using MyFigure.Helpers;
using System;

namespace MyFigure
{
    /// <summary>
    /// Фигура - Прямоугольник
    /// Пример добавления новой фигуры - по-моему не сложно
    /// </summary>
    public class Rectangle : Figure, IEquatable<Rectangle>
    {
        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentOutOfRangeException("Стороны прямоугольника должены быть больше 0.");

            Width = width;
            Height = height;
        }

        public double Height { get; private set; }
        public double Width { get; private set; }
        public bool IsSquare => Width == Height;

        public override double Square => Width * Height;
        public override double Perimeter => (Width + Height) * 2;

        public override object Clone() => new Rectangle(Width, Height);

        public override bool Equals(object obj) => Equals(obj as Rectangle);
        public bool Equals(Rectangle other) => other != null && Width == other.Width && Height == other.Height;

        public override int GetHashCode() => HashHelper.RSHash(Width, Height);

        protected override string ParamsInfo => $"{Width}, {Height}";
    }
}
