using System;
using NET.W._2019.Gorodko._03.Task1.GCDAlgorithms;
using NUnit.Framework;

namespace NET.W._2019.Gorodko._03.Tests.Task1.GCDAlgorithms
{
    [TestFixture]
    public class BinaryAlgorithmTests
    {
        [Test]
        public void Execute_ArgumentIs0_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new BinaryAlgorithm().Execute(0, 1));
            Assert.Throws<ArgumentException>(() => new BinaryAlgorithm().Execute(1, 0));
        }

        [TestCase(20, 10, ExpectedResult = 10)]
        [TestCase(1, 22, ExpectedResult = 1)]
        [TestCase(3, 15, ExpectedResult = 3)]
        [TestCase(100, 45, ExpectedResult = 5)]
        [TestCase(102, 15, ExpectedResult = 3)]
        [TestCase(15, 30, ExpectedResult = 15)]
        [TestCase(12, 42, ExpectedResult = 6)]
        [TestCase(17, 12, ExpectedResult = 1)]
        public int Execute_ReturnsRightGCD(int number1, int number2)
        {
            return new BinaryAlgorithm().Execute(number1, number2);
        }
    }
}
