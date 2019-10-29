using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFigure;

namespace MyFigureTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void Circle_Perimeter_Test()
        {
            const double r = 11;
            var c = new Circle(r);
            var p = c.Perimeter;
            Assert.AreEqual(p, 2 * Math.PI * r);
        }

        [TestMethod]
        public void Circle_Square_Test()
        {
            const double r = 19;
            var c = new Circle(r);
            var s = c.Square;
            Assert.AreEqual(s, Math.PI * r * r);
        }

        [TestMethod]
        public void Circle_Equals_Test()
        {
            const double r = 31;
            var c1 = new Circle(r);
            var c2 = new Circle(r);
            Assert.AreEqual(c1, c2);
        }

        [TestMethod]
        public void Circle_Clone_Test()
        {
            const double r = 37;
            var c1 = new Circle(r);
            var c2 = c1.Clone();
            Assert.AreEqual(c1, c2);
        }
    }
}
