using System;
using NUnit.Framework;
using Task1.Domain;

namespace Task1.Tests
{
    [TestFixture]
    public class BookTests
    {
        private readonly Book book;

        public BookTests()
        {
            book = new Book("1234567890121", "Author1", "Title1", "Publisher1", 1, 1, 1);
        }

        [Test]
        public void ToString_FormatIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => book.ToString(null, null));
        }

        [TestCase("ISBN", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1")]
        [TestCase("ISBN, author", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1, Author1")]
        [TestCase("ISBN, author, title", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1, Author1, Title1")]
        [TestCase("ISBN, author, title, publisher", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1, Author1, Title1, \"Publisher1\"")]
        [TestCase("ISBN, author, title, publisher, year", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1, Author1, Title1, \"Publisher1\", 1")]
        [TestCase("ISBN, author, title, publisher, year, pages", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1, Author1, Title1, \"Publisher1\", 1, P.1")]
        [TestCase("ISBN, author, title, publisher, year, pages, price", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1, Author1, Title1, \"Publisher1\", 1, P.1, 1$")]
        [TestCase("ISBN/year", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1, 1")]
        [TestCase("ISBN/author/publisher", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1, Author1, \"Publisher1\"")]
        [TestCase("titleisbnauthor", null, ExpectedResult = "ISBN 13: 123-4-5678-9012-1, Author1, Title1")]
        public string ToString_ReturnsRightString(string format, IFormatProvider formatProvider)
        {
            return book.ToString(format, formatProvider);
        }
    }
}
