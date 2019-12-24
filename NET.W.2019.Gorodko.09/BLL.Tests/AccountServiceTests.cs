using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface.Entities.Accounts;
using BLL.Interface.Entities.BonusSystems;
using DAL.Interface.Interfaces;
using NUnit.Framework;
using Moq;
using DAL.Interface.DTO;
using BLL.ServiceImplementation;
using BLL.Interface.Entities;

namespace BLL.Tests
{
    [TestFixture]
    public class AccountServiceTests
    {
        private Mock<IRepository> mock;

        private AccountService service;

        public AccountServiceTests()
        {
            this.SetMock();
            this.service = new AccountService(mock.Object);
        }

        [Test]
        public void AccountService_RepositoryIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AccountService(null));
        }

        [Test]
        public void CreateAccount_CreatesAndAddsAccount()
        {
            var id = service.CreateAccount(AccountType.CashbackAccount, BonusSystemType.Gold);

            Assert.IsTrue(service.Accounts.Where(a => a.Id == id).Count() == 1);
        }

        [Test]
        public void CloseAccount_ClosesAccount()
        {
            var accountToClose = service[1];

            service.CloseAccount(1);

            Assert.IsTrue(accountToClose.IsClosed);
        }

        [Test]
        public void Deposit_DepositsRight()
        {
            var accountToDeposit = service[2];

            service.Deposit(2, 100);

            Assert.IsTrue(accountToDeposit.Balance == 100);
        }

        [Test]
        public void Withdraw_WithdrawsRight()
        {
            var accountToWithdraw = service[3];

            service.Withdraw(3, 50);

            Assert.IsTrue(accountToWithdraw.Balance == 50);
        }

        private void SetMock()
        {
            mock = new Mock<IRepository>();
            var accounts = new List<AccountDTO>();
            accounts.Add(
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

            accounts.Add(
                new AccountDTO
                {
                    AccountType = typeof(CashbackAccount).ToString(),
                    BonusSystemType = typeof(GoldBonusSystem).ToString(),
                    IsClosed = false,
                    Id = 2,
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    Balance = 0,
                    Cashback = 111,
                    CashbackPercent = 2,
                });

            accounts.Add(
                new AccountDTO
                {
                    AccountType = typeof(DefaultAccount).ToString(),
                    BonusSystemType = typeof(BaseBonusSystem).ToString(),
                    IsClosed = false,
                    Id = 3,
                    FirstName = "FirstName3",
                    LastName = "LastName3",
                    Balance = 100,
                    Cashback = 0,
                    CashbackPercent = 0,
                });
            mock.Setup(s => s.Load()).Returns(accounts);
        }
    }
}
