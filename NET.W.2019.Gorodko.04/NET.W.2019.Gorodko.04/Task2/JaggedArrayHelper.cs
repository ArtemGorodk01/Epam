using System;
using System.Collections.Generic;

namespace NET.W._2019.Gorodko._04.Task2
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
        public static void Sort(this int[][] array, Func<int[], int[], int> compare, bool isUp)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (compare == null)
            {
                throw new ArgumentNullException(nameof(compare));
            }

            CheckJaggedArray(array);

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i; j++)
                {
                    if (isUp ? compare(array[j], array[j + 1]) > 0 : compare(array[j], array[j + 1]) < 0)
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
        public static void Sort(this int[][] array, IComparer<int[]> comparer, bool isUp)
        {
            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            Sort(array, comparer.Compare, isUp);
        }

        /// <summary>
        /// Compares two arrays by summation of elements
        /// </summary>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        /// <returns>
        /// First sum - second sum
        /// </returns>
        public static int CompareArraySum(int[] array1, int[] array2)
        {
            if (array1 == null)
            {
                throw new ArgumentNullException(nameof(array1));
            }

            if (array2 == null)
            {
                throw new ArgumentNullException(nameof(array2));
            }

            int sum1 = 0,
                sum2 = 0;

            foreach (var item in array1)
            {
                sum1 += item;
            }

            foreach (var item in array2)
            {
                sum2 += item;
            }

            return sum1 - sum2;
        }

        /// <summary>
        /// Compares two arrays by maximum
        /// </summary>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        /// <returns>
        /// First maximum - second maximum
        /// </returns>
        public static int CompareArrayMax(int[] array1, int[] array2)
        {
            if (array1 == null)
            {
                throw new ArgumentNullException(nameof(array1));
            }

            if (array2 == null)
            {
                throw new ArgumentNullException(nameof(array2));
            }

            int max1 = FindMax(array1),
                max2 = FindMax(array2);

            return max1 - max2;
        }

        /// <summary>
        /// Compares two arrays by minimum
        /// </summary>
        /// <param name="array1">First array</param>
        /// <param name="array2">Second array</param>
        /// <returns>
        /// First minimum - second minimum
        /// </returns>
        public static int CompareArrayMin(int[] array1, int[] array2)
        {
            if (array1 == null)
            {
                throw new ArgumentNullException(nameof(array1));
            }

            if (array2 == null)
            {
                throw new ArgumentNullException(nameof(array2));
            }

            int min1 = FindMin(array1),
                min2 = FindMin(array2);

            return min1 - min2;
        }

        /// <summary>
        /// Returns maximum of array
        /// </summary>
        /// <param name="array">Source array</param>
        /// <returns>Maximum of array</returns>
        private static int FindMax(int[] array)
        {
            var max = int.MinValue;
            foreach (var item in array)
            {
                if (item > max)
                {
                    max = item;
                }
            }

            return max;
        }

        /// <summary>
        /// Returns minimum of array
        /// </summary>
        /// <param name="array">Source array</param>
        /// <returns>Minimum of array</returns>
        private static int FindMin(int[] array)
        {
            var min = int.MaxValue;
            foreach (var item in array)
            {
                if (item < min)
                {
                    min = item;
                }
            }

            return min;
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
