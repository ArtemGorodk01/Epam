using System;
using NET.W._2019.Gorodko._03.Task1.GCDAlgorithms.Abstarct;

namespace NET.W._2019.Gorodko._03.Task1
{
    /// <summary>
    /// Contains static method for the calculation the greatest common divisor
    /// </summary>
    public static class GCDCalculator
    {
        /// <summary>
        /// Calculates the greatest common divisor by classic euclidean algorithm
        /// </summary>
        /// <param name="time">Out argument which shows the execution time in milliseconds</param>
        /// <param name="algorithm">The algorithm of calculation the greatest common divisor</param>
        /// <param name="number1">The number for the calculation GCD. Can't be 0</param>
        /// <param name="number2">The number for the calculation GCD. Can't be 0</param>
        /// <param name="numbers">Other numbers for calculation GCD. Can't be 0</param>
        /// <returns>The greatest common divisor of numbers</returns>
        public static int Calculate(out long time, IGCDAlgorithm algorithm, int number1, int number2, params int[] numbers)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (algorithm == null)
            {
                throw new ArgumentNullException(nameof(algorithm));
            }

            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }

            int tmpGcd = algorithm.Execute(number1, number2);

            for (int i = 0; i < numbers.Length; i++)
            {
                tmpGcd = algorithm.Execute(tmpGcd, numbers[i]);
            }

            watch.Stop();
            time = watch.ElapsedMilliseconds;

            return tmpGcd;
        }
    }
}
