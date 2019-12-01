using System.Collections.Generic;
using Task2.Domain;

namespace Task2.Storage.Abstract
{
    /// <summary>
    /// Defines storage and methods for working with it
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Writes all bank accounts from collection into the storage
        /// </summary>
        /// <param name="bankAccounts"></param>
        void WriteAll(List<BankAccount> bankAccounts);

        /// <summary>
        /// Reads data from storage
        /// </summary>
        /// <returns>List with bank accounts</returns>
        List<BankAccount> ReadAll();
    }
}