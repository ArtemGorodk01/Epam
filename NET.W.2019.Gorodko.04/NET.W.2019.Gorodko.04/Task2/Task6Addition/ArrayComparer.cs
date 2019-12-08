using System;
using System.Collections.Generic;

namespace NET.W._2019.Gorodko._04.Task2.Task6Addition
{
    /// <summary>
    /// Implements IComparer<int[]>
    /// </summary>
    public class ArrayComparer : IComparer<int[]>
    {
        /// <summary>
        /// Delegate for comparison
        /// </summary>
        private readonly Func<int[], int[], int> compare;

        /// <summary>
        /// Initials new object
        /// </summary>
        /// <param name="compare">Delegate for comparison</param>
        public ArrayComparer(Func<int[], int[], int> compare)
        {
            this.compare = compare ?? throw new ArgumentNullException(nameof(compare));
        }

        /// <summary>
        /// Compares two arrays
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public int Compare(int[] x, int[] y)
        {
            return this.compare(x, y);
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

    }
}
