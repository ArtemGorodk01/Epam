using System;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class SquareMatrixTests
    {
        [Test]
        public void SquareMatrix_SizeIsNegative_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new SquareMatrix<object>(-1));
        }

        [Test]
        public void Size_SizeIs5_Returns5()
        {
            var matrix = new SquareMatrix<object>(5);

            Assert.That(matrix.Size == 5);
        }

        [Test]
        public void Indexator_IndexIsWrong_ThrowsIndexOutOfRangeException()
        {
            var matrix = new SquareMatrix<int>(3);
            int tmp;

            Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[-1, 0]);
            Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[0, -1]); Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[5, 0]);
            Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[0, 5]);
            Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[-1, -1]);
            Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[5, 5]);
        }

        [TestCase(1, 1, 1, ExpectedResult = 1)]
        [TestCase(4, 1, 2, ExpectedResult = 4)]
        [TestCase(7, 0, 2, ExpectedResult = 7)]
        public int Indexator_GetsAndSetsRightValue(int value, int i, int j)
        {
            var matrix = new SquareMatrix<int>(3);
            matrix[i, j] = value;

            return matrix[i, j];
        }
    }
}
