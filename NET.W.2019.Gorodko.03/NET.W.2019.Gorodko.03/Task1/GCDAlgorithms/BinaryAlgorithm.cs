using System;
using NET.W._2019.Gorodko._03.Task1.GCDAlgorithms.Abstarct;

namespace NET.W._2019.Gorodko._03.Task1.GCDAlgorithms
{
    /// <summary>
    /// Contains binary algorithm of calculation the greatest common divisor
    /// </summary>
    public class BinaryAlgorithm : IGCDAlgorithm
    {
        /// <summary>
        /// Calculates the greatest common divisor by binary algorithm
        /// </summary>
        /// <param name="number1">The number for calculation GCD. Can't be 0</param>
        /// <param name="number2">The number for calculation GCD. Can't be 0</param>
        /// <returns>The greatest common divisor of numbers</returns>
        public int Execute(int number1, int number2)
        {
            if (number1 == 0 || number2 == 0)
            {
                throw new ArgumentException("Arguments can't be 0");
            }

            if (number1 < 0)
            {
                number1 = Math.Abs(number1);
            }

            if (number2 < 0)
            {
                number2 = Math.Abs(number2);
            }

            int degree = 0;
            while (number1 != number2)
            {
                if (number1 % 2 == 0)
                {
                    number1 /= 2;
                    if (number2 % 2 == 0)
                    {
                        degree++;
                        number2 /= 2;
                    }

                    continue;
                }

                if (number2 % 2 == 0)
                {
                    number2 /= 2;
                    continue;
                }

                if (number1 > number2)
                {
                    number1 = (number1 - number2) / 2;
                    continue;
                }

                number2 = (number2 - number1) / 2;
            }

            return (int)Math.Pow(2, degree) * number1;
        }
    }
}
