using System;
using NUnit.Framework;
using System.Globalization;
using Task1.Domain;

namespace Task1.Tests
{
    [TestFixture]
    public class BookFormatterTests
    {
        private readonly BookFormatter formatter;

        private readonly Book book;

        public BookFormatterTests()
        {
            formatter = new BookFormatter();
            book = new Book("1234567890121", "Author1", "Title1", "Publisher1", 1, 1, 1);
        }

        [Test]
        public void Format_FormatIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => formatter.Format(null, new object(), CultureInfo.CurrentCulture));
        }

        [Test]
        public void Format_ArgIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => formatter.Format(string.Empty, null, CultureInfo.CurrentCulture));
        }

        [Test]
        public void Format_ArgIsNotBook_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => formatter.Format(string.Empty, new object(), null));
        }

        [TestCase("full", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1, Author1, Title1, \"Publisher1\", 1, P.1, 1$")]
        [TestCase("ISBN, author", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1, Author1")]
        [TestCase("random string", null, ExpectedResult = "")]
        public string Format_ReturnsRightString(string format, IFormatProvider formatProvider)
        {
            return formatter.Format(format, book, formatProvider);
        }
    }
}
