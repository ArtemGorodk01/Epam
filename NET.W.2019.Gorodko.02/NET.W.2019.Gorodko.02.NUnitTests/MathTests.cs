using System;
using NUnit.Framework;

namespace NET.W._2019.Gorodko._02.NUnitTests
{
    using NET.W._2019.Gorodko._02.Task5;

    [TestFixture]
    public class MathTests
    {
        [Test]
        public void FindNthRoot_RootLess0_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Math.FindNthRoot(1, -1, 0.0001));
        }

        [Test]
        public void FindNthRoot_NumberLess0RootIsEven_ThrowsArgumentExcption()
        {
            Assert.Throws<ArgumentException>(() => Math.FindNthRoot(-1, 2, 0.00002));
        }

        [Test]
        public void FindNthRoot_AccuracyLess0_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Math.FindNthRoot(1, 2, -1));
        }

        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_ReturnsRightResult(double number, int root, double accuracy, double expected)
        {
            Assert.AreEqual(expected, Math.FindNthRoot(number, root, accuracy), accuracy);
        }
    }
}
