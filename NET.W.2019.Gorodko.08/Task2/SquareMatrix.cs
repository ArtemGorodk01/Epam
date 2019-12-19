using System;
using Task2.Abstract;

namespace Task2
{
    /// <inheritdoc/>
    public class SquareMatrix<T> : IMatrix<T>
    {
        /// <summary>
        /// The matrix.
        /// </summary>
        protected readonly T[,] Matrix;

        /// <summary>
        /// Initials the new instance of square matrix.
        /// </summary>
        /// <param name="size">The size of the matrix.</param>
        public SquareMatrix(int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Size of matrix must be positive.");
            }

            this.Size = size;
            this.Matrix = new T[Size, Size];
        }

        /// <inheritdoc/>
        public event EventHandler OnChangeElement;

        /// <inheritdoc/>
        public int Size { get; }

        /// <inheritdoc/>
        public T this[int i, int j]
        {
            get
            {
                this.CheckGetArguments(i, j);
                return this.GetElement(i, j);
            }

            set
            {
                this.CheckSetArguments(i, j);
                this.SetElement(i, j, value);
                if (this.OnChangeElement != null)
                {
                    this.OnChangeElement.Invoke(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// Checks set indexes.
        /// </summary>
        /// <param name="i">Left index.</param>
        /// <param name="j">Right index.</param>
        protected virtual void CheckSetArguments(int i, int j)
        {
            if (i < 0 || i >= this.Size)
            {
                throw new IndexOutOfRangeException("Wrong index i.");
            }

            if (j < 0 || j >= this.Size)
            {
                throw new IndexOutOfRangeException("Wrong index j.");
            }
        }

        /// <summary>
        /// Checks get indexes.
        /// </summary>
        /// <param name="i">Left index.</param>
        /// <param name="j">Right index.</param>
        protected virtual void CheckGetArguments(int i, int j)
        {
            if (i < 0 || i >= this.Size)
            {
                throw new IndexOutOfRangeException("Wrong index i.");
            }

            if (j < 0 || j >= this.Size)
            {
                throw new IndexOutOfRangeException("Wrong index j.");
            }
        }

        /// <summary>
        /// Gets elements by indexes.
        /// </summary>
        /// <param name="i">Left index.</param>
        /// <param name="j">Right index.</param>
        /// <returns>The element.</returns>
        protected virtual T GetElement(int i, int j)
        {
            return this.Matrix[i, j];
        }

        /// <summary>
        /// Sets elements by indexes.
        /// </summary>
        /// <param name="i">Left index.</param>
        /// <param name="j">Right index.</param>
        /// <param name="element">The element.</param>
        protected virtual void SetElement(int i, int j, T element)
        {
            this.Matrix[i, j] = element;
        }
    }
}
