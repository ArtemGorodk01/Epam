using System;
using System.Collections.Generic;
using Task2.Domain;
using Task2.Storage.Abstract;

namespace Task2.Service
{
    /// <summary>
    /// Provides working with storage of bank accounts
    /// </summary>
    public class BankService
    {
        /// <summary>
        /// Collection with bank accounts
        /// </summary>
        private List<BankAccount> _bankAccounts;

        /// <summary>
        /// Storage with data about bank accounts
        /// </summary>
        private IStorage _storage;

        /// <summary>
        /// Initials new service
        /// </summary>
        /// <param name="storage">Storage of bank accounts</param>
        public BankService(IStorage storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            _bankAccounts = new List<BankAccount>();
        }

        /// <summary>
        /// Gets current count of accounts in internal collection
        /// </summary>
        public int CountOfAccounts
        {
            get => _bankAccounts.Count;
        }

        /// <summary>
        /// Provides access to bank account by index in internal collection
        /// </summary>
        /// <param name="index">Index</param>
        public BankAccount this[int index]
        {
            get
            {
                if (index < 0 || index >= CountOfAccounts)
                {
                    throw new IndexOutOfRangeException();
                }

                return _bankAccounts[index];
            }
        }

        /// <summary>
        /// Reads data about bank account from storage
        /// </summary>
        /// <returns>Current service</returns>
        public BankService Load()
        {
            _bankAccounts = _storage.ReadAll();
            return this;
        }

        /// <summary>
        /// Writes data about bank accounts into storage
        /// </summary>
        /// <returns>Current service</returns>
        public BankService Save()
        {
            _storage.WriteAll(_bankAccounts);
            return this;
        }

        /// <summary>
        /// Adds account to internal collection
        /// </summary>
        /// <param name="account">Bank account</param>
        /// <returns>Current service</returns>
        public BankService AddAccount(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (_bankAccounts.Contains(account))
            {
                throw new ArgumentException("Account already exists");
            }

            _bankAccounts.Add(account);
            return this;
        }

        /// <summary>
        /// Removes account from internal collection
        /// </summary>
        /// <param name="account">Bank account</param>
        /// <returns>Current service</returns>
        public BankService RemoveAccount(BankAccount account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (!_bankAccounts.Contains(account))
            {
                throw new ArgumentException("Account doesn't exist");
            }

            _bankAccounts.Remove(account);
            return this;
        }
    }
}
