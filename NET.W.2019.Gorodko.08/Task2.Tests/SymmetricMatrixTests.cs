using System;
using NUnit.Framework;

namespace Task2.Tests
{
    [TestFixture]
    public class SymmetricMatrixTests
    {
        [Test]
        public void SymmetricMatrix_SizeIsNegative_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new SymmetricMatrix<object>(-1));
        }

        [Test]
        public void Size_SizeIs5_Returns5()
        {
            var matrix = new SymmetricMatrix<object>(5);

            Assert.That(matrix.Size == 5);
        }

        [Test]
        public void Indexator_IndexIsWrong_ThrowsIndexOutOfRangeException()
        {
            var matrix = new SymmetricMatrix<int>(3);
            int tmp;

            Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[-1, 0]);
            Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[0, -1]); Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[5, 0]);
            Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[0, 5]);
            Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[-1, -1]);
            Assert.Throws<IndexOutOfRangeException>(() => tmp = matrix[5, 5]);
        }

        [TestCase(1, 1, 1)]
        [TestCase(4, 1, 2)]
        [TestCase(7, 0, 2)]
        public void Indexator_GetsAndSetsRightValue(int value, int i, int j)
        {
            var matrix = new SymmetricMatrix<int>(3);
            matrix[i, j] = value;

            Assert.That(matrix[i, j] == value && matrix[j, i] == value);
        }
    }
}
