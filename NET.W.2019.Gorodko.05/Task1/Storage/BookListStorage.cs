using System;
using System.Collections.Generic;
using System.IO;
using Task1.Domain;
using Task1.Storage.Abstract;

namespace Task1.Storage
{
    public sealed class BookListStorage : IStorage
    {
        /// <summary>
        /// File path
        /// </summary>
        private const string FilePath = @"Storage.bin";

        /// <summary>
        /// Object for synchronization
        /// </summary>
        private static readonly object Sync = new object();

        /// <summary>
        /// Instance of global storage
        /// </summary>
        private static volatile BookListStorage _instance;

        private BookListStorage()
        {
        }

        /// <summary>
        /// Provides access to storage
        /// Controls correct working with threads
        /// </summary>
        public static BookListStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new BookListStorage();
                        }
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// Reads all books from file 
        /// </summary>
        /// <returns>Collection with books</returns>
        public List<Book> ReadAll()
        {
            if (!File.Exists(FilePath))
            {
                throw new InvalidOperationException("Wrong file path");
            }

            var result = new List<Book>();

            using (var binaryReader = new BinaryReader(File.Open(FilePath, FileMode.Open)))
            {
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    result.Add(ReadBook(binaryReader));
                }
            }

            return result;
        }

        /// <summary>
        /// Writes all books from collection to the file
        /// </summary>
        /// <param name="books">Collection with books</param>
        public void WriteAll(List<Book> books)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }

            using (var binaryWriter = new BinaryWriter(File.Open(FilePath, FileMode.Create)))
            {
                foreach (var book in books)
                {
                    WriteBook(binaryWriter, book);
                }
            }
        }

        /// <summary>
        /// Reads data from file
        /// </summary>
        /// <param name="binaryReader">File adapter</param>
        /// <returns>Book</returns>
        private Book ReadBook(BinaryReader binaryReader)
        {
            if (binaryReader == null)
            {
                throw new ArgumentNullException(nameof(binaryReader));
            }

            var isbn = binaryReader.ReadString();
            var author = binaryReader.ReadString();
            var title = binaryReader.ReadString();
            var publisher = binaryReader.ReadString();
            var year = binaryReader.ReadInt32();
            var pages = binaryReader.ReadInt32();
            var price = binaryReader.ReadDecimal();

            return new Book(isbn, author, title, publisher, year, pages, price);
        }

        /// <summary>
        /// Writes data to the file
        /// </summary>
        /// <param name="binaryWriter">File adapter</param>
        /// <param name="book">Data</param>
        private void WriteBook(BinaryWriter binaryWriter, Book book)
        {
            if (binaryWriter == null)
            {
                throw new ArgumentNullException(nameof(binaryWriter));
            }

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            binaryWriter.Write(book.ISBN);
            binaryWriter.Write(book.Author);
            binaryWriter.Write(book.Title);
            binaryWriter.Write(book.Publisher);
            binaryWriter.Write(book.Year);
            binaryWriter.Write(book.Pages);
            binaryWriter.Write(book.Price);
        }
    }
}
