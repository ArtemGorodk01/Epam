using System;

namespace Task2
{
    /// <summary>
    /// Provides working with diagonal matrix.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initials new instance of diagonal matrix.
        /// </summary>
        /// <param name="size">The size of matrix.</param>
        public DiagonalMatrix(int size) : base(size)
        {
        }

        /// <inheritdoc/>
        protected override void CheckSetArguments(int i, int j)
        {
            base.CheckSetArguments(i, j);
            if (i != j)
            {
                throw new ArgumentException("Only elements with same indexes are changable for diagonal matrix.");
            }
        }

        /// <inheritdoc/>
        protected override T GetElement(int i, int j)
        {
            if (i == j)
            {
                return base.GetElement(i, j);
            }

            return default(T);
        }
    }
}
