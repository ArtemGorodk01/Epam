using System;
using NUnit.Framework;
using Task2.Decorators;

namespace Task2.Tests
{
    [TestFixture]
    public class SummDecoratorTests
    {
        [Test]
        public void SummDecorator_ArgIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new SummDecorator<object>(null));
        }

        [Test]
        public void Summ_ArgIsNull_ThrowsArgumentNullException()
        {
            var matrix = new SummDecorator<object>(new SquareMatrix<object>(1));
            SummDecorator<object> tmp;

            Assert.Throws<ArgumentNullException>(() => tmp = matrix + null);
        }

        [Test]
        public void Summ_TypeParameterIsObject_ThrowsInvalidOperationException()
        {
            var matrix = new SummDecorator<object>(new SquareMatrix<object>(1));
            SummDecorator<object> tmp;

            Assert.Throws<InvalidOperationException>(() => tmp = matrix + matrix);
        }

        [Test]
        public void Summ_ReturnsRightValue()
        {
            var matrix = new SummDecorator<int>(new SquareMatrix<int>(1));
            matrix[0, 0] = 1;

            var expected = new SummDecorator<int>(new SquareMatrix<int>(1));
            expected[0, 0] = 2;

            Assert.That(MatrixEquals(matrix + matrix, expected));
        }

        private bool MatrixEquals<T>(SummDecorator<T> matrix1, SummDecorator<T> matrix2)
        {
            if (matrix1.Size != matrix2.Size)
            {
                return false;
            }

            for (int i = 0; i < matrix1.Size; i++)
            {
                for (int j = 0; j < matrix1.Size; j++)
                {
                    if (!matrix1[i, j].Equals(matrix2[i, j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
