using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.BonusSystems;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    /// <inheritdoc/>
    public class FakeRepository : IRepository
    {
        private List<AccountDTO> accounts;

        /// <summary>
        /// Initials new fake repository.
        /// </summary>
        public FakeRepository()
        {
            this.accounts = new List<AccountDTO>();
            this.accounts.Add(
                new AccountDTO
                {
                    AccountType = typeof(DefaultAccount).ToString(),
                    BonusSystemType = typeof(BaseBonusSystem).ToString(),
                    IsClosed = false,
                    Id = 1,
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Balance = 1,
                    Cashback = 0,
                    CashbackPercent = 0,
                });

            this.accounts.Add(
                new AccountDTO
                {
                    AccountType = typeof(CashbackAccount).ToString(),
                    BonusSystemType = typeof(GoldBonusSystem).ToString(),
                    IsClosed = false,
                    Id = 2,
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    Balance = 2,
                    Cashback = 111,
                    CashbackPercent = 2,
                });
        }

        /// <inheritdoc/>
        public IEnumerable<AccountDTO> Load()
        {
            return this.accounts;
        }

        /// <inheritdoc/>
        public void Save(IEnumerable<AccountDTO> accounts)
        {
            if (accounts == null)
            {
                throw new ArgumentNullException(nameof(accounts));
            }

            this.accounts = accounts.ToList();
        }
    }
}
