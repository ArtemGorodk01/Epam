using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NET.W._2019.Gorodko._02.Task1;

namespace NET.W._2019.Gorordko._02.MSTests
{
    [TestClass]
    public class NumberInsertionTests
    {
        [TestMethod]
        public void InsertNumber_IMoreJ_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => NumberInsertion.InsertNumber(1, 1, 1, 0));
        }

        [TestMethod]
        public void InsertNumber_JLess0_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => NumberInsertion.InsertNumber(1, 1, -3, -1));
        }

        [DataTestMethod]
        [DataRow(15, 15, 0, 0, 15)]
        [DataRow(8, 15, 0, 0, 9)]
        [DataRow(8, 15, 3, 8, 120)]
        [DataRow(3, 3, 1, 1, 3)]
        [DataRow(12, 15, 0, 1, 15)]
        public void InsertNumber_ReturnsRightResult(int number1, int number2, int i, int j, int expectedResult)
        {
            int result = NumberInsertion.InsertNumber(number1, number2, i, j);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
