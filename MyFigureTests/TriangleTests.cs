using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFigure;

namespace MyFigureTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void Triangle_Perimeter_Test()
        {
            var t = new Triangle(1, 2, 3);
            var p = t.Perimeter;
            Assert.AreEqual(p, 1 + 2 + 3);
        }

        [TestMethod]
        public void Triangle_Square_Test()
        {
            const double a = 11, b = 12, c = 13;
            var t = new Triangle(a, b, c);
            
            var s1 = t.Square;
            var p = (a + b + c) / 2;
            var s2 = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            Assert.AreEqual(s1, s2);
        }

        [TestMethod]
        public void Triangle_Equals_Test()
        {
            const double a = 11, b = 12, c = 13;
            var t1 = new Triangle(a, b, c);
            var t2 = new Triangle(b, c, a);

            Assert.AreEqual(t1, t2);
        }

        [TestMethod]
        public void Triangle_Clone_Test()
        {
            const double a = 17, b = 19, c = 23;
            var t1 = new Triangle(a, b, c);
            var t2 = t1.Clone();

            Assert.AreEqual(t1, t2);
        }

        [TestMethod]
        public void Triangle_Equilateral_Test()
        {
            const double a = 1, b = 1, c = 1;
            var t = new Triangle(a, b, c);

            var res = t.IsEquilateral;

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Triangle_Not_Equilateral_Test()
        {
            const double a = 2, b = 2, c = 3;
            var t = new Triangle(a, b, c);

            var res = t.IsEquilateral;

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Triangle_Rectangular_Test()
        {
            const double a = 5, b = 3, c = 4;
            var t = new Triangle(a, b, c);

            var res = t.IsRectangular;

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Triangle_Not_Rectangular_Test()
        {
            const double a = 25, b = 33, c = 144;
            var t = new Triangle(a, b, c);

            var res = t.IsRectangular;

            Assert.IsFalse(res);
        }
    }
}
