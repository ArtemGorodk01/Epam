using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Task2.Domain;
using Task2.Domain.BonusSystem.Abstract;
using Task2.Storage.Abstract;

namespace Task2.Storage
{
    public sealed class FileStorage : IStorage
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
        private static volatile FileStorage _instance;

        private FileStorage()
        {
        }

        /// <summary>
        /// Provides access to storage
        /// Controls correct working with threads
        /// </summary>
        public static FileStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Sync)
                    {
                        if (_instance == null)
                        {
                            _instance = new FileStorage();
                        }
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// Reads data from storage
        /// </summary>
        /// <returns>List with bank accounts</returns>
        public List<BankAccount> ReadAll()
        {
            if (!File.Exists(FilePath))
            {
                throw new InvalidOperationException("Wrong file path");
            }

            var result = new List<BankAccount>();

            using (var binaryReader = new BinaryReader(File.Open(FilePath, FileMode.Open)))
            {
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    result.Add(ReadAccount(binaryReader));
                }
            }

            return result;
        }

        /// <summary>
        /// Writes all bank accounts from collection into the storage
        /// </summary>
        /// <param name="bankAccounts">Collection of bank accounts</param>
        public void WriteAll(List<BankAccount> bankAccounts)
        {
            if (bankAccounts == null)
            {
                throw new ArgumentNullException(nameof(bankAccounts));
            }

            using (var binaryWriter = new BinaryWriter(File.Open(FilePath, FileMode.Create)))
            {
                foreach (var account in bankAccounts)
                {
                    WriteAccount(binaryWriter, account);
                }
            }
        }

        /// <summary>
        /// Reads data from file
        /// </summary>
        /// <param name="reader">File adapter</param>
        /// <returns>Bank account</returns>
        public BankAccount ReadAccount(BinaryReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            var id = reader.ReadInt32();
            var firstName = reader.ReadString();
            var lastName = reader.ReadString();
            var balance = reader.ReadDecimal();
            var accountType = reader.ReadInt32();
            var isActive = reader.ReadBoolean();
            var bonusSystemTypeName = reader.ReadString();

            var typeOfBonusSystem = Type.GetType(bonusSystemTypeName);

            var bankAccount = new BankAccount(id, firstName, lastName, balance,
                                  typeOfBonusSystem, (AccountType)accountType, isActive);

            return bankAccount;
        }

        /// <summary>
        /// Writes data to the file
        /// </summary>
        /// <param name="writer">File adapter</param>
        /// <param name="account">Bank account</param>
        public void WriteAccount(BinaryWriter writer, BankAccount account)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            writer.Write(account.Id);
            writer.Write(account.FirstName);
            writer.Write(account.LastName);
            writer.Write(account.Balance);
            writer.Write((int)account.AccountType);
            writer.Write(account.IsActive);
            writer.Write(account.BonusSystemType.ToString());
        }
    }
}
