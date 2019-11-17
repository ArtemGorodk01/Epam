using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.W._2019.Gorodko._02.Task23;

namespace NET.W._2019.Gorordko._02.MSTests
{
    [TestClass]
    public class FinderTests
    {
        [TestMethod]
        public void FindNextBiggerNumber_NumberLess0_ThrowsArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Finder.FindNextBiggerNumber(-1));
        }

        [DataTestMethod]
        [DataRow(12, 21)]
        [DataRow(513, 531)]
        [DataRow(2017, 2071)]
        [DataRow(414, 441)]
        [DataRow(144, 414)]
        [DataRow(1234321, 1241233)]
        [DataRow(1234126, 1234162)]
        [DataRow(3456432, 3462345)]
        [DataRow(10, -1)]
        [DataRow(20, -1)]
        public void FindNextBiggerNumber_ReturnsRightNumber(int number, int expectedResult)
        {
            int result = Finder.FindNextBiggerNumber(number);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
