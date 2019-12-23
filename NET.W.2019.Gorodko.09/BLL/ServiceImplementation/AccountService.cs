using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.Accounts.Abstract;
using BLL.Interface.Entities.BonusSystems;
using BLL.Interface.Entities.BonusSystems.Abstract;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    /// <summary>
    /// Provides working with collection of accounts.
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IRepository repository;

        private Dictionary<int, Account> accounts;

        /// <summary>
        /// Initials new instance of account service.
        /// </summary>
        public AccountService(IRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            accounts = new Dictionary<int, Account>();
        }

        /// <inheritdoc/>
        public IEnumerable<Account> Accounts
        {
            get
            {
                return accounts.Select(n => n.Value).ToList();
            }
        }

        /// <summary>
        /// Provides access to account by id.
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Account.</returns>
        public Account this[int id]
        {
            get
            {
                if (!accounts.ContainsKey(id))
                {
                    throw new InvalidOperationException("No account with definite account.");
                }

                return accounts[id];
            }
        }

        /// <inheritdoc/>
        public void CloseAccount(int id)
        {
            this[id].Close();
        }

        /// <inheritdoc/>
        public int CreateAccount(AccountType accountType, BonusSystemType bonusSystemType)
        {
            BonusSystem bonusSystem;
            switch (bonusSystemType)
            {
                case BonusSystemType.Base:
                    bonusSystem = new BaseBonusSystem();
                    break;
                case BonusSystemType.Gold:
                    bonusSystem = new GoldBonusSystem();
                    break;
                case BonusSystemType.Platinum:
                    bonusSystem = new PlatinumBonusSystem();
                    break;
                default:
                    throw new InvalidOperationException("Unregistered type of bonus system.");
            }

            int id = this.CreateId();
            Account account;
            switch (accountType)
            {
                case AccountType.DefaultAccount:
                    account = new DefaultAccount(id, bonusSystem);
                    break;
                case AccountType.CashbackAccount:
                    account = new CashbackAccount(id, bonusSystem, 0);
                    break;
                default:
                    throw new InvalidOperationException("Unregistered type of account.");
            }

            accounts.Add(account.Id, account);
            return account.Id;
        }

        /// <inheritdoc/>
        public void Deposit(int id, decimal deposit)
        {
            accounts[id].Deposit(deposit);
        }

        /// <inheritdoc/>
        public void Withdraw(int id, decimal withdraw)
        {
            accounts[id].Withdraw(withdraw);
        }

        /// <inheritdoc/>
        public void ReadAll()
        {
            var accounts = repository
                               .Load()
                               .Select(n => n.ToAccount())
                               .ToDictionary(n => n.Id, n => n);
        }

        /// <inheritdoc/>
        public void WriteAll()
        {
            var accountList = accounts.ToList().Select(n => n.Value);
            repository.Save(accountList.Select(n => n.ToAccountDTO()));
        }

        private int CreateId()
        {
            int id;
            do
            {
                id = Guid.NewGuid().GetHashCode();
            }
            while (accounts.ContainsKey(id));
            return id;
        }
    }
}
