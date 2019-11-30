﻿using System;

namespace Task1.Domain
{
    public class Book : IComparable, IComparable<Book>, IEquatable<Book>
    {
        #region Private fields

        private string _isbn;
        private string _author;
        private string _title;
        private string _publisher;
        private int _year;
        private int _pages;
        private decimal _price;

        #endregion

        /// <summary>
        /// Creates new book
        /// </summary>
        /// <param name="isbn"></param>
        /// <param name="author"></param>
        /// <param name="title"></param>
        /// <param name="publisher"></param>
        /// <param name="year"></param>
        /// <param name="pages"></param>
        /// <param name="price"></param>
        public Book(string isbn, string author, string title, string publisher, int year, int pages, decimal price)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            Pages = pages;
            Price = price;
        }

        #region Properties

        /// <summary>
        /// ISBN
        /// </summary>
        public string ISBN
        {
            get => _isbn;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(value);
                }

                if (value.Length != 13)
                {
                    throw new ArgumentException("Wrong ISBN");
                }

                foreach (var symbol in value)
                {
                    if (!int.TryParse(symbol.ToString(), out int tmp))
                    {
                        throw new ArgumentException("Wrong ISBN");
                    }
                }

                _isbn = value;
            }
        }

        /// <summary>
        /// Author name
        /// </summary>
        public string Author
        {
            get => _author;
            set => _author = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Book title
        /// </summary>
        public string Title
        {
            get => _title;
            set => _title = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Publisher
        /// </summary>
        public string Publisher
        {
            get => _publisher;
            set => _publisher = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Year of publishing book
        /// </summary>
        public int Year
        {
            get => _year;
            set
            {
                if (!(value > 0 && value <= DateTime.Now.Year))
                {
                    throw new ArgumentException("Wrong year");
                }

                _year = value;
            }
        }

        /// <summary>
        /// Count of pages
        /// </summary>
        public int Pages
        {
            get => _pages;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Wrong number of pages");
                }

                _pages = value;
            }
        }

        /// <summary>
        /// Price of the book
        /// </summary>
        public decimal Price
        {
            get => _price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Wrong price");
                }

                _price = value;
            }
        }

        #endregion

        #region Object overrides

        /// <summary>
        /// Returns are objects equal 
        /// (two books are the same if its ISBN is the same)
        /// </summary>
        /// <param name="obj">Object for comparison</param>
        /// <returns>Are objects equal </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return true;
            }

            if (!(obj is Book book))
            {
                return false;
            }

            return this.Equals(book);
        }

        /// <summary>
        /// Gets hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            if (ISBN == null)
            {
                return 0;
            }

            int hash = 0;
            for (int i = 0; i < 7; i++)
            {
                hash += int.Parse(ISBN[i].ToString());
                hash <<= 4;
            }

            hash += int.Parse(ISBN[7].ToString());
            return hash;
        }

        /// <summary>
        /// Returns string with ISBN
        /// </summary>
        /// <returns>String with ISBN</returns>
        public override string ToString()
        {
            return ISBN;
        }

        #endregion

        #region IComparable and IEquatable methods

        /// <summary>
        /// Compares objects 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Result of comparison</returns>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            if (object.ReferenceEquals(obj, this))
            {
                return 0;
            }

            if (!(obj is Book book))
            {
                return 1;
            }

            return CompareTo(book);
        }

        /// <summary>
        /// Compares books
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Result of comparison</returns>
        public int CompareTo(Book book)
        {
            if (book == null)
            {
                return 1;
            }

            if (object.ReferenceEquals(book, this))
            {
                return 0;
            }

            return ISBN.CompareTo(book.ISBN);
        }

        /// <summary>
        /// Returns are objects the same
        /// </summary>
        /// <param name="other">Object for comparison</param>
        /// <returns>Are objects the same</returns>
        public bool Equals(Book other)
        {
            if (other == null)
            {
                return false;
            }

            if (object.ReferenceEquals(other, this))
            {
                return true;
            }

            if (other.ISBN == ISBN)
            {
                return true;
            }

            return false;
        }

        #endregion

        /// <summary>
        /// Contains tags for book parameters
        /// </summary>
        public enum Tag
        {
            ISBN,
            Author,
            Title,
            Publisher,
            Year,
            Pages,
            Price
        }
    }
}
