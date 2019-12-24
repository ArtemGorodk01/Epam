using System;
using BLL.Interface.Entities.BonusSystems.Abstract;

namespace BLL.Interface.Entities.Accounts.Abstract
{
    /// <summary>
    /// Provides working with bank account.
    /// </summary>
    public abstract class Account
    {
        /// <summary>
        /// Initials new account.
        /// </summary>
        /// <param name="bonusSystem">The bonus system.</param>
        public Account(int id, BonusSystem bonusSystem, bool isClosed = false)
        {
            this.Id = id;
            this.BonusSystem = bonusSystem ??
                               throw new ArgumentNullException(nameof(bonusSystem));
            this.IsClosed = isClosed;
        }

        /// <summary>
        /// Gets the bonus system.
        /// </summary>
        public BonusSystem BonusSystem { get; }

        /// <summary>
        /// Gets is account closed.
        /// </summary>
        public bool IsClosed { get; private set; }

        /// <summary>
        /// Gets the balance.
        /// </summary>
        public decimal Balance { get; set; }

        /// <summary>
        /// Gets the id of the account.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets or sets first name of the card owner.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets last name of the card owner.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Changes balance, bonuses and does additional actions.
        /// </summary>
        /// <param name="withdraw">Value of withdraw.</param>
        public void Withdraw(decimal withdraw)
        {
            if (this.IsClosed)
            {
                throw new InvalidOperationException("Account is closed.");
            }

            if (withdraw < 0)
            {
                throw new ArgumentException("Withdraw must be positive.");
            }

            if (withdraw > this.Balance)
            {
                throw new ArgumentException("Withdraw must be less than balance.");
            }

            BonusSystem.OnWithdraw(withdraw);
            this.Balance -= withdraw;
            this.AdditionalWithdrawAction(withdraw);
        }

        /// <summary>
        /// Changes balance, bonuses and does additional actions.
        /// </summary>
        /// <param name="deposit">Value of deposit.</param>
        public void Deposit(decimal deposit)
        {
            if (this.IsClosed)
            {
                throw new InvalidOperationException("Account is closed.");
            }

            if (deposit < 0)
            {
                throw new ArgumentException("Deposit must be positive.");
            }

            BonusSystem.OnDeposit(deposit);
            this.Balance += deposit;
            this.AdditionalDepositAction(deposit);
        }

        /// <summary>
        /// Closes account.
        /// </summary>
        public void Close()
        {
            if (IsClosed)
            {
                throw new InvalidOperationException("Account is closed.");
            }

            IsClosed = true;
        }

        /// <summary>
        /// Does actions on withdraw for definite type of account.
        /// </summary>
        /// <param name="withdraw">Value of withdraw.</param>
        protected abstract void AdditionalWithdrawAction(decimal withdraw);

        /// <summary>
        /// Does actions on deposit for definite type of account.
        /// </summary>
        /// <param name="deposit">Value of deposit.</param>
        protected abstract void AdditionalDepositAction(decimal deposit);
    }
}
