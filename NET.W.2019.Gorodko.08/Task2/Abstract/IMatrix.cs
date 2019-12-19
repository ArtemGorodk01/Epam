using System;

namespace Task2.Abstract
{
    /// <summary>
    /// Provides working with matrix.
    /// </summary>
    /// <typeparam name="T">Type of elements of matrix.</typeparam>
    public interface IMatrix<T>
    {
        /// <summary>
        /// The event on change element.
        /// </summary>
        event EventHandler OnChangeElement;

        /// <summary>
        /// The size of the matrix.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Provides access to matrix elements by their indexes.
        /// </summary>
        /// <param name="i">The first index.</param>
        /// <param name="j">The second index.</param>
        /// <returns>Matrix element.</returns>
        T this[int i, int j]
        {
            get;
            set;
        }
    }
}
