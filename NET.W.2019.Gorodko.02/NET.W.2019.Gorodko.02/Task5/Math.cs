using System;

namespace NET.W._2019.Gorodko._02.Task5
{
    /// <summary>
    /// Contains method for finding root from the number
    /// </summary>
    public static class Math
    {
        /// <summary>
        /// Finds the root of the number
        /// </summary>
        /// <param name="number">Source number</param>
        /// <param name="root">Degree of the root</param>
        /// <param name="accuracy">Accuracy</param>
        /// <returns>The root of the number</returns>
        public static double FindNthRoot(double number, int root, double accuracy)
        {
            if (root <= 0)
                throw new ArgumentOutOfRangeException(nameof(root), "root must be larger than 0");

            if (root % 2 == 0 && number < 0)
                throw new ArgumentException("Number must be larger than 0 for even roots");

            if (accuracy <= 0)
                throw new ArgumentOutOfRangeException(nameof(accuracy), "accuracy must be larger than 0");

            double prev = 1, cur = 1;

            do
            {
                prev = cur;
                cur = (1 / (double)root) * ((root - 1) * prev + number / System.Math.Pow(prev, root - 1));
            } while (System.Math.Abs(cur - prev) > accuracy);

            return cur;
        }
    }
}
