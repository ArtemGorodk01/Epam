using System;

namespace NET.W._2019.Gorodko._02.Task23
{
    /// <summary>
    /// Task2
    /// Contains method for finding first bigger number 
    /// that contains only digits of source number
    /// Task3
    /// Contains methods that calculate execution time
    /// </summary>
    public static class Finder
    {
        /// <summary>
        /// Finds the first bigger number that conatains only digits of source number.
        /// </summary>
        /// <param name="number">The source number</param>
        /// <returns>
        /// The first bigger number that conatains only digits of source number.
        /// If number doesn't exist returns -1.
        /// </returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException(nameof(number), "The number must be larger than 0");

            //Devide the source number into array (each digit)
            var array = CreateArray(number);
            //Put digits in the right order
            ProcessArray(array);
            //Transform array
            int result = GetNumberFromArray(array);

            return number == result ? -1 : result;
        }

        /// <summary>
        /// Finds the first bigger number that conatains only digits of source number.
        /// Calculates execution time of method FindNextBiggerNumber(int) using StopWatch
        /// </summary>
        /// <param name="number">The source number</param>
        /// <param name="ticks">
        /// Out parameter that contains count of ticks
        /// (execution time of method FindNextBiggerNumber(int))
        /// </param>
        /// <returns>
        /// The first bigger number that conatains only digits of source number.
        /// If number doesn't exist returns -1.
        /// </returns>
        public static int FindNextBiggerNumber(int number, out long ticks)
        {
            int result;

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            result = FindNextBiggerNumber(number);
 
            sw.Stop();

            ticks = sw.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Finds the first bigger number that conatains only digits of source number.
        /// Calculates execution time of method FindNextBiggerNumber(int) using Environment.TickCount
        /// </summary>
        /// <param name="number">The source number</param>
        /// <param name="ticks">
        /// Out parameter that contains count of ticks
        /// (execution time of method FindNextBiggerNumber(int))
        /// </param>
        /// <returns>
        /// The first bigger number that conatains only digits of source number.
        /// If number doesn't exist returns -1.
        /// </returns>
        public static int FindNextBiggerNumber(int number, out int ticks)
        {
            int result;

            int start = Environment.TickCount;

            result = FindNextBiggerNumber(number);

            int end = Environment.TickCount;

            ticks = end - start;
            return result;
        }

        /// <summary>
        /// Calculates int number from int number
        /// </summary>
        /// <param name="array">The array with digits of the number</param>
        /// <returns>Number that contains each digit from array</returns>
        private static int GetNumberFromArray(int[] array)
        {
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] * (int)Math.Pow(10, array.Length - i - 1);
            }

            return result;
        }

        /// <summary>
        /// Changes the order of elements in the array
        /// </summary>
        /// <param name="array">source array</param>
        private static void ProcessArray(int[] array)
        {
            //Find the first number
            //which right neighbor is more than itself
            int i = array.Length - 1;
            bool isChangable = false;
            while (i > 0)
            {
                if (array[i] > array[--i])
                {
                    isChangable = true;
                    break;
                }
            }

            if (!isChangable)
                return;
            //change element and his right neughbor
            (array[i], array[i + 1]) = (array[i + 1], array[i]);
            //sort the right part of array
            SortPartArray(array, i + 1, array.Length - 1);
        }

        /// <summary>
        /// Orders the part of the array from leftIndex to rightIndex
        /// </summary>
        /// <param name="array">Source array</param>
        /// <param name="leftIndex">The index of the first element which has to ordered</param>
        /// <param name="rightIndex">The index of the last element which has to ordered</param>
        private static void SortPartArray(int[] array, int leftIndex, int rightIndex)
        {
            if (rightIndex - leftIndex < 1)
                return;

            int i = leftIndex + 1;
            while (i <= rightIndex)
            {
                int input = array[i];
                int j = i - 1;

                while (j >= leftIndex && input < array[j])
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = input;
                i++;
            }
        }

        /// <summary>
        /// Fills in the array with digits of the number
        /// </summary>
        /// <param name="number">Source number</param>
        /// <returns>Result array</returns>
        private static int[] CreateArray(int number)
        {
            int rank = GetRank(number);
            var resArr = new int[rank];

            for (int i = rank - 1; i > -1; i--)
            {
                resArr[i] = number % 10;
                number = number / 10;
            }

            return resArr;
        }

        /// <summary>
        /// Returns the count of the digits in source number
        /// </summary>
        /// <param name="number">Source of the number</param>
        /// <returns>Rank of the number</returns>
        private static int GetRank(int number)
        {
            int rank = 0;

            while (number > 9)
            {
                rank++;
                number /= 10;
            }

            return rank + 1;
        }
    }
}
