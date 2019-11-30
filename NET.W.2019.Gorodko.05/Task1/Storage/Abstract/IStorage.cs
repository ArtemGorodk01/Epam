using System.Collections.Generic;
using Task1.Domain;

namespace Task1.Storage.Abstract
{
    /// <summary>
    /// Defines storage and methods for working with it
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Writes data in storage
        /// </summary>
        /// <param name="books">List with books</param>
        void WriteAll(List<Book> books);

        /// <summary>
        /// Reads data from storage
        /// </summary>
        /// <returns>List with books</returns>
        List<Book> ReadAll();
    }
}
