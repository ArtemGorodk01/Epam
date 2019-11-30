using System;
using System.Collections.Generic;

namespace Task1.Domain
{
    /// <summary>
    /// Provides comparison of books
    /// </summary>
    internal class BookComparer : IComparer<Book>
    {
        /// <summary>
        /// Tag which is used like parameter of comparison
        /// </summary>
        private readonly Book.Tag _tag;

        /// <summary>
        /// Initials the object
        /// </summary>
        /// <param name="tag"></param>
        public BookComparer(Book.Tag tag = Book.Tag.ISBN)
        {
            _tag = tag;
        }
        
        /// <summary>
        /// Compares two books
        /// </summary>
        /// <param name="book1"></param>
        /// <param name="book2"></param>
        public int Compare(Book book1, Book book2)
        {
            if (book1 == null)
            {
                throw new ArgumentNullException(nameof(book1));
            }

            if (book2 == null)
            {
                throw new ArgumentNullException(nameof(book2));
            }

            switch (_tag)
            {
                case Book.Tag.ISBN:
                    return book1.ISBN.CompareTo(book2.ISBN);

                case Book.Tag.Author:
                    return book1.Author.CompareTo(book2.Author);

                case Book.Tag.Publisher:
                    return book1.Publisher.CompareTo(book2.Author);

                case Book.Tag.Title:
                    return book1.Title.CompareTo(book2.Title);

                case Book.Tag.Pages:
                    return book1.Pages.CompareTo(book2.Pages);

                case Book.Tag.Year:
                    return book1.Year.CompareTo(book2.Year);

                case Book.Tag.Price:
                    return book1.Price.CompareTo(book2.Price);

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
