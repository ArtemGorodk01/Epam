using System;
using System.Collections.Generic;

namespace NET.W._2019.Gorodko._04.Task2.Task6Addition
{
    /// <summary>
     /// Contains methods for working with jagged array
     /// </summary>
    public static class JaggedArrayHelper
    {
        /// <summary>
        /// Extension method for jagged array
        /// Sorts array using delegate
        /// </summary>
        /// <param name="array">Source array</param>
        /// <param name="compare">The way of comparing two line arrays</param>
        /// <param name="isUp">
        /// True: from minimum to maximum
        /// False: from maximum to minimum
        /// </param>
        public static void Sort(this int[][] array, IComparer<int[]> comparer, bool isUp)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            CheckJaggedArray(array);

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (isUp ? comparer.Compare(array[j], array[j + 1]) > 0 : comparer.Compare(array[j], array[j + 1]) < 0)
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                }
            }
        }

        /// <summary>
        /// Extension method for jagged array
        /// Sorts array using IComparer<int[]>
        /// </summary>
        /// <param name="array">Source array</param>
        /// <param name="compare">The way of comparing two line arrays</param>
        /// <param name="isUp">
        /// True: from minimum to maximum
        /// False: from maximum to minimum
        /// </param>
        public static void Sort(this int[][] array, Func<int[], int[], int> compare, bool isUp)
        {
            if (compare == null)
            {
                throw new ArgumentNullException(nameof(compare));
            }

            Sort(array, new ArrayComparer(compare), isUp);
        }

        /// <summary>
        /// Throws
        /// ArgumentNullException if one of arrays is null
        /// ArgumentException if one of arrays is empty
        /// </summary>
        /// <param name="array">Jagged array</param>
        private static void CheckJaggedArray(int[][] array)
        {
            foreach (var item in array)
            {
                if (item == null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                if (item.Length == 0)
                {
                    throw new ArgumentException("Array in jagged array can't be empty");
                }
            }
        }
    }
}
