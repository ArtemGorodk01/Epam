using System.Text;

namespace NET.W._2019.Gorodko._03.Task2
{
    /// <summary>
    /// Contains extension method for System.Double 
    /// which returns string with binary view of the number
    /// </summary>
    public static class DoubleHelper
    {
        /// <summary>
        /// Returns string with binary view of the number in IEEE754 format
        /// </summary>
        /// <param name="number">Source number</param>
        /// <returns>String with binary view of the number in IEEE754 format</returns>
        public static string GetBinaryView(this double number)
        {
            ulong ulongNumber;
            unsafe
            {
                double* numberRef = &number;
                ulong* ulongNumberRef = (ulong*)numberRef;
                ulongNumber = *ulongNumberRef;
            }

            return GetBitsFromUlong(ulongNumber);
        }

        /// <summary>
        /// Returns string with binary view of the number
        /// </summary>
        /// <param name="number">Source number</param>
        /// <returns>String with binary view of the number</returns>
        private static string GetBitsFromUlong(ulong number)
        {
            // size of ulong in bits
            const int ULONG_SIZE = sizeof(ulong) * 8;

            var sb = new StringBuilder(ULONG_SIZE);

            for (int i = ULONG_SIZE - 1; i > -1; i--)
            {
                sb.Append(number % 2);
                number /= 2;
            }

            return InvertString(sb.ToString());
        }

        /// <summary>
        /// Returns inverted string
        /// </summary>
        /// <param name="source">Source string</param>
        /// <returns>Invert string</returns>
        private static string InvertString(string source)
        {
            var sb = new StringBuilder();

            for (int i = source.Length - 1; i > -1; i--)
            {
                sb.Append(source[i]);
            }

            return sb.ToString();
        }
    }
}
