using System;
using System.Globalization;

namespace Task1.Domain
{
    /// <summary>
    /// Adds format
    /// </summary>
    public class BookFormatter : ICustomFormatter
    {
        /// <summary>
        /// Returns string using format for object in second argument
        /// </summary>
        /// <param name="format">Format</param>
        /// <param name="arg">Object to formatting</param>
        /// <param name="formatProvider">Format provider</param>
        /// <returns>String using format for object in second argument</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (format == null)
            {
                throw new ArgumentNullException(nameof(format));
            }

            if (arg == null)
            {
                throw new ArgumentNullException(nameof(arg));
            }

            if (!(arg is Book book))
            {
                throw new ArgumentException("Wrong type of argument");
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            if (format.Trim().ToUpperInvariant() == "FULL")
            {
                return book.ToString("isbn, author, title, publisher, year, pages, price", formatProvider);
            }

            return book.ToString(format, formatProvider);
        }
    }
}
