using System;
using Task2.Abstract;

namespace Task2.Decorators.Abstract
{
    /// <inheritdoc/>
    public abstract class MatrixDecorator<T> : IMatrix<T>
    {
        /// <summary>
        /// The matrix.
        /// </summary>
        private SquareMatrix<T> squareMatrix;

        /// <summary>
        /// Initials the new decorator.
        /// </summary>
        /// <param name="squareMatrix"></param>
        public MatrixDecorator(SquareMatrix<T> squareMatrix)
        {
            this.squareMatrix = squareMatrix ?? throw new ArgumentNullException(nameof(squareMatrix));
        }

        /// <inheritdox/>
        public event EventHandler OnChangeElement
        {
            add
            {
                squareMatrix.OnChangeElement += value;
            }

            remove
            {
                squareMatrix.OnChangeElement += value;
            }
        }

        /// <inheritdoc/>
        public int Size => squareMatrix.Size;

        /// <inheritdoc/>
        public T this[int i, int j]
        {
            get
            {
                return squareMatrix[i, j];
            }

            set
            {
                squareMatrix[i, j] = value;
            }
        }
    }
}
