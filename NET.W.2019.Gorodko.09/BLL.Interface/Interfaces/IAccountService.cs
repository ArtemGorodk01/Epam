using System.Collections.Generic;
using BLL.Interface.Entities;
using BLL.Interface.Entities.Accounts.Abstract;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Provides working with
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Gets collection with all accounts in service.
        /// </summary>
        IEnumerable<Account> Accounts { get; }

        /// <summary>
        /// Creates new account and adds it to collection.
        /// </summary>
        /// <param name="accountType">Account system type.</param>
        /// <param name="bonusSystemType">Bonus system type.</param>
        /// <returns>Id of new account.</returns>
        int CreateAccount(AccountType accountType, BonusSystemType bonusSystemType);

        /// <summary>
        /// Closes account.
        /// </summary>
        /// <param name="id">Id of account.</param>
        void CloseAccount(int id);

        /// <summary>
        /// Makes deposit.
        /// </summary>
        /// <param name="id">Id of the account.</param>
        /// <param name="deposit">Deposit.</param>
        void Deposit(int id, decimal deposit);

        /// <summary>
        /// Makes withdraw.
        /// </summary>
        /// <param name="id">Id of the account.</param>
        /// <param name="withdraw">Withdraw.</param>
        void Withdraw(int id, decimal withdraw);

        /// <summary>
        /// Saves all records.
        /// </summary>
        void WriteAll();

        /// <summary>
        /// Reads all records.
        /// </summary>
        void ReadAll();
    }
}
