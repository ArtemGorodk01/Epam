using System;
using System.Collections.Generic;
using Task1.Domain;
using Task1.Storage.Abstract;

namespace Task1.Service
{
    /// <summary>
    /// Provides work with collection of books
    /// </summary>
    public class BookListService
    {
        /// <summary>
        /// Provides working with the storage
        /// </summary>
        private readonly IStorage _storage;

        /// <summary>
        /// Collection with books
        /// </summary>
        private List<Book> _books;

        /// <summary>
        /// Initials new service
        /// </summary>
        /// <param name="storage">Storage</param>
        public BookListService(IStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _books = new List<Book>();
        }

        /// <summary>
        /// Returns the count of books
        /// </summary>
        public int CountOfBooks
        {
            get => _books.Count;
        }

        /// <summary>
        /// Provides access to books in internal collection
        /// </summary>
        /// <param name="index">Index of book</param>
        /// <returns>Book</returns>
        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= _books.Count)
                {
                    throw new IndexOutOfRangeException();
                }

                return _books[index];
            }
        }

        /// <summary>
        /// Adds book to internal collection
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns>Current service</returns>
        public BookListService AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (_books.Contains(book))
            {
                throw new ArgumentException("Book is already in internal collection");
            }

            _books.Add(book);
            return this;
        }

        /// <summary>
        /// Removes book from internal collection
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns>Current service</returns>
        public BookListService RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (!_books.Contains(book))
            {
                throw new ArgumentException("Book is not in the internal collection");
            }

            _books.Remove(book);
            return this;
        }

        /// <summary>
        /// Find books by value in definite tag
        /// </summary>
        /// <typeparam name="T">Type of value to search</typeparam>
        /// <param name="tag">Property name of book</param>
        /// <param name="findBook">Book</param>
        /// <returns>Collection with find books</returns>
        public IEnumerable<Book> FindBooksByTag(Book findBook, Book.Tag tag = Book.Tag.ISBN)
        {
            if (findBook == null)
            {
                throw new ArgumentNullException(nameof(findBook));
            }

            var bookComparer = new BookComparer(tag);
            var result = new List<Book>();

            foreach (var book in _books)
            {
                if (bookComparer.Compare(book, findBook) == 0)
                {
                    result.Add(book);
                }
            }

            return result;
        }

        /// <summary>
        /// Sorts collection by tag
        /// </summary>
        /// <param name="tag">Property name of book</param>
        /// <returns>Current service</returns>
        public BookListService SortBooksByTag(Book.Tag tag = Book.Tag.ISBN)
        {
            var bookComparer = new BookComparer(tag);
            _books.Sort(bookComparer);
            return this;
        }

        /// <summary>
        /// Reads all books from the storage into internal collection
        /// </summary>
        /// <returns>Current service</returns>
        public BookListService Load()
        {
            _books = _storage.ReadAll();
            return this;
        }

        /// <summary>
        /// Writes all books from internal collection into storage
        /// </summary>
        /// <returns>Current service</returns>
        public BookListService Save()
        {
            _storage.WriteAll(_books);
            return this;
        }
    }
}
