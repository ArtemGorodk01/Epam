using System;
using NET.W._2019.Gorodko._02.Task1;
using NUnit.Framework;

namespace NET.W._2019.Gorodko._02.NUnitTests
{
    [TestFixture]
    public class NumberInsertionTests
    {
        [Test]
        public void InsertNumber_IMoreJ_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => NumberInsertion.InsertNumber(1, 1, 1, 0));
        }

        [Test]
        public void InsertNumber_JLess0_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => NumberInsertion.InsertNumber(1, 1, -3, -1));
        }

        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        [TestCase(3, 3, 1, 1, ExpectedResult = 3)]
        [TestCase(12, 15, 0, 1, ExpectedResult = 15)]
        public int InsertNumber_ReturnsRightResult(int number1, int number2, int i, int j)
        {
            return NumberInsertion.InsertNumber(number1, number2, i, j);
        }
    }
}
