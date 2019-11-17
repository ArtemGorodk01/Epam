using System;
using System.Collections.Generic;

namespace NET.W._2019.Gorodko._02.Task4
{
    /// <summary>
    /// Contains filter method
    /// </summary>
    public static class Filter
    {
        /// <summary>
        /// Returns sequence of numbers, which contain the digit
        /// </summary>
        /// <param name="digit">Digit for search</param>
        /// <param name="array">Source array of numbers</param>
        /// <returns>Array with numbers, that contain the digit</returns>
        public static int[] FilterDigit(int digit, params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (digit < 0 || digit > 9)
                throw new ArgumentOutOfRangeException(nameof(digit), "Argument digit must be a digit (0-9)");

            var result = new List<int>();
            string sdigit = digit.ToString();

            foreach (var item in array)
            {
                if (item.ToString().Contains(sdigit))
                    result.Add(item);
            }

            return result.ToArray();
        }
    }
}
