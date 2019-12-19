namespace Task2
{
    /// <summary>
    /// Provides working with symmetricMatrix.
    /// </summary>
    /// <typeparam name="T">Type of matrix elements.</typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        /// <summary>
        /// Initials the new matrix.
        /// </summary>
        /// <param name="size">The size of matrix.</param>
        public SymmetricMatrix(int size) : base(size)
        {
        }

        /// <inheritdoc/>
        protected override void SetElement(int i, int j, T element)
        {
            this.Matrix[i, j] = element;
            this.Matrix[j, i] = element;
        }
    }
}
