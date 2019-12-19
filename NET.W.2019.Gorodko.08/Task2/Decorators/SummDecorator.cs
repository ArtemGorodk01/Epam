using System;
using Task2.Decorators.Abstract;

namespace Task2.Decorators
{
    public class SummDecorator<T> : MatrixDecorator<T>
    {
        /// <summary>
        /// Initials the new summation decorator.
        /// </summary>
        /// <param name="matrix">The matrix.</param>
        public SummDecorator(SquareMatrix<T> matrix) : base(matrix)
        {
        }

        /// <summary>
        /// Summates matrix.
        /// </summary>
        /// <param name="left">The left argument.</param>
        /// <param name="right">The right argument.</param>
        /// <returns>The summation of left and right arguments.</returns>
        public static SummDecorator<T> operator +(SummDecorator<T> left, SummDecorator<T> right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            if (left.Size != right.Size)
            {
                throw new ArgumentException("Objects can not be summed.");
            }

            var result = new SummDecorator<T>(
                             new SquareMatrix<T>(left.Size));

            for (int i = 0; i < left.Size; i++)
            {
                for (int j = 0; j < left.Size; j++)
                {
                    dynamic leftDynamic = left[i, j];
                    dynamic rightDynamic = right[i, j];
                    try
                    {
                        result[i, j] = leftDynamic + rightDynamic;
                    }
                    catch
                    {
                        throw new InvalidOperationException($"Type {typeof(T)} can not be summed");
                    }
                }
            }

            return result;
        }
    }
}
