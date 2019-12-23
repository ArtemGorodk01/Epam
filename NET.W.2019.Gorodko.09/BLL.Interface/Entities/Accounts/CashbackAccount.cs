using System;
using BLL.Interface.Entities.Accounts.Abstract;
using BLL.Interface.Entities.BonusSystems.Abstract;

namespace BLL.Interface.Entities.Accounts
{
    /// <inheritdoc/>
    public class CashbackAccount : Account
    {
        private double cashbackPercent;

        /// <summary>
        /// Initials new instance of bank account with cashback.
        /// </summary>
        /// <param name="bonusSystem">Bonus system.</param>
        /// <param name="cashbackPercent">Cashback percent.</param>
        public CashbackAccount(int id, BonusSystem bonusSystem, decimal cashback, bool isClosed = false) : base(id, bonusSystem, isClosed)
        {
            this.Cashback = cashback;
        }

        /// <summary>
        /// Gets or sets cashback percent.
        /// </summary>
        public double CashbackPercent
        {
            get
            {
                return cashbackPercent;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Percent is number in range 0-100.");
                }

                cashbackPercent = value;
            }
        }

        /// <summary>
        /// Gets cashback.
        /// </summary>
        public decimal Cashback { get; private set; }

        /// <inheritdoc/>
        protected override void AdditionalDepositAction(decimal deposit)
        {
            // No additional actions for cashback account.
        }

        /// <inheritdoc/>
        protected override void AdditionalWithdrawAction(decimal withdraw)
        {
            if (withdraw < 0)
            {
                throw new ArgumentException("Withdraw must be positive.");
            }

            Cashback += withdraw * (decimal)CashbackPercent;
        }
    }
}
