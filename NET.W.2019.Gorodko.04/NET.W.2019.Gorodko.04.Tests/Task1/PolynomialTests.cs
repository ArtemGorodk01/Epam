using System;
using NET.W._2019.Gorodko._04.Task1;
using NUnit.Framework;

namespace NET.W._2019.Gorodko._04.Tests.Task1
{
    [TestFixture]
    public class PolynomialTests
    {
        [Test]
        public void Equals_SameObject_ReturnsTrue()
        {
            var polynom1 = new Polynomial(2.01, 2.02);
            var polynom2 = new Polynomial(2.01, 2.02);

            Assert.IsTrue(polynom1.Equals(polynom2));
        }

        [Test]
        public void Equals_DifferentObject_ReturnsFalse()
        {
            var polynom1 = new Polynomial(2.01, 2.02);
            var polynom2 = new Polynomial(2);

            Assert.IsFalse(polynom1.Equals(polynom2));
        }

        [Test]
        public void GetHashCode_SameObject_SameHashCode()
        {
            var polynom1 = new Polynomial(2.01, 2.02);
            var polynom2 = new Polynomial(2.01, 2.02);

            Assert.IsTrue(polynom1.GetHashCode() == polynom2.GetHashCode());
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = new double[] { 2, 4, 6, 8, 10 })]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = new double[] { 2, 4, 6, 4, 5 })]
        [TestCase(new double[] { 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = new double[] { 5, 7, 3, 4, 5 })]
        public double[] OperatorPlus_ReturnsRightResult(double[] arg1, double[] arg2)
        {
            var polynom1 = new Polynomial(arg1);
            var polynom2 = new Polynomial(arg2);

            return polynom1 + polynom2;
        }

        [Test]
        public void OperatorPlus_ArgumentIsNull_ThrowsArgumentNullException()
        {
            var polynom = new Polynomial(2);

            Assert.Throws<ArgumentNullException>(() => polynom = polynom + null);
            Assert.Throws<ArgumentNullException>(() => polynom = null + polynom);
        }

        [TestCase(new double[] { 1, 2, 3, 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = new double[] { 0, 0, 0, 0, 0 })]
        [TestCase(new double[] { 1, 2, 3 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = new double[] { 0, 0, 0, -4, -5 })]
        [TestCase(new double[] { 4, 5 }, new double[] { 1, 2, 3, 4, 5 }, ExpectedResult = new double[] { 3, 3, -3, -4, -5 })]
        [TestCase(new double[] { 0, 0.1 }, new double[] { 0.1, 0.2 }, ExpectedResult = new double[] { -0.1, -0.1 })]
        public double[] OperatorMinus_ReturnsRightResult(double[] arg1, double[] arg2)
        {
            var polynom1 = new Polynomial(arg1);
            var polynom2 = new Polynomial(arg2);

            return polynom1 - polynom2;
        }

        [Test]
        public void OperatorMinus_ArgumentIsNull_ThrowsArgumentNullException()
        {
            var polynom = new Polynomial(2);

            Assert.Throws<ArgumentNullException>(() => polynom = polynom - null);
            Assert.Throws<ArgumentNullException>(() => polynom = null - polynom);
        }

        [TestCase(new double[] { 1, 2 }, new double[] { 1 }, ExpectedResult = new double[] { 1, 2 })]
        [TestCase(new double[] { 1, 2 }, new double[] { 1, 2 }, ExpectedResult = new double[] { 1, 4, 4 })]
        [TestCase(new double[] { 4, 5 }, new double[] { 1, 2 }, ExpectedResult = new double[] { 4, 13, 10 })]
        public double[] OperatorMult_ReturnsRightResult(double[] arg1, double[] arg2)
        {
            Polynomial polynom1 = arg1;
            Polynomial polynom2 = arg2;

            return polynom1 * polynom2;
        }

        [Test]
        public void OperatorMult_ArgumentIsNull_ThrowsArgumentNullException()
        {
            var polynom = new Polynomial(2);

            Assert.Throws<ArgumentNullException>(() => polynom = polynom * null);
            Assert.Throws<ArgumentNullException>(() => polynom = null * polynom);
        }

        [Test]
        public void OperatorEquals_SameObjects_ReturnsTrue()
        {
            var polynom1 = new Polynomial(2);
            var polynom2 = new Polynomial(2);

            Assert.IsTrue(polynom1 == polynom2);
        }

        [Test]
        public void OperatorNotEquals_SameObjects_ReturnsFalse()
        {
            var polynom1 = new Polynomial(2);
            var polynom2 = new Polynomial(2);

            Assert.IsFalse(polynom1 != polynom2);
        }
    }
}
