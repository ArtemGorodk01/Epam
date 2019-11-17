using System;

namespace NET.W._2019.Gorodko._02.Task1
{
    /// <summary>
     /// Task 1
     /// Contains static method for insertion bits
     /// </summary>
    public static class NumberInsertion
    {
        /// <summary>
        /// insert j - i + 1 right bits of number2 
        /// into i-j bits of multiplication bits of number1 and number2
        /// </summary>
        /// <param name="number1">the number for multiplication</param>
        /// <param name="number2">the number for multiplication and insertion</param>
        /// <param name="i">the index of the first bit for insertion</param>
        /// <param name="j">the index of the last bit for insertion</param>
        /// <returns>
        /// result of multiplication of number1 and number2
        /// and insertion of needed bits
        /// </returns>
        public static int InsertNumber(int number1, int number2, int i, int j)
        {
            if (i > j)
                throw new ArgumentException("Parameter j must be larger than i");

            if (j < 0)
                throw new ArgumentException("Parameters i and j must be larger than -1");

            //result of + function
            int tempResult = number1 & number2;
            //get into leftBits bits after the last insertion bit
            int leftBits = CalculateLeftBitsToInt(tempResult, j + 1);
            //get into rightBits bits before the first insertion bit
            int rightBits = CalculateRightBitsToInt(tempResult, i);
            //git into insertionBits bits from i-bit to j-bit
            int insertionBits = CalculateRightBitsToInt(number2, j - i + 1);

            //the result is sum of:
            //rightBits without offset
            //insertionBits with offset that equals i
            //leftBits with offset that equls j + 1
            return rightBits + (insertionBits << i) + (leftBits << j + 1);
        }

        /// <summary>
        /// Calculates int number that contains left bits without offset
        /// </summary>
        /// <param name="number">Source number</param>
        /// <param name="offset">Offset</param>
        /// <returns>Int number that contains left bits</returns>
        private static int CalculateLeftBitsToInt(int number, int offset)
        {
            return number >> offset;
        }

        /// <summary>
        /// Calculates int number putting 1 in each bit
        /// </summary>
        /// <param name="countOfBits">Count of 1 in the result binary number</param>
        /// <returns>Int number which contains only 1 in binary view</returns>
        private static int CalculateNumberWithBits1(int countOfBits)
        {
            int result = 0;

            for (int i = 0; i < countOfBits; i++)
            {
                result += (int)Math.Pow(2, i);
            }

            return result;
        }

        /// <summary>
        /// Calculates int number which contains countOfBits right bits of source number
        /// </summary>
        /// <param name="number">Source number</param>
        /// <param name="countOfBits">Count of needed right bits</param>
        /// <returns>Int number that contains countOfBits right bits of source number</returns>
        private static int CalculateRightBitsToInt(int number, int countOfBits)
        {
            return number & CalculateNumberWithBits1(countOfBits);
        }
    }
}
