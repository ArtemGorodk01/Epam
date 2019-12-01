using System;

namespace Task2.Domain.BonusSystem.Abstract
{
    /// <summary>
    /// Abstract class for bonus system
    /// </summary>
    public abstract class BonusSystemBase
    {
        /// <summary>
        /// Initials bonus system
        /// </summary>
        /// <param name="type">Type of account</param>
        public BonusSystemBase(AccountType type)
        {
            Type = type;
            SetCosts();
        }

        /// <summary>
        /// Balance cost
        /// </summary>
        protected int BalanceCost { get; set; }

        /// <summary>
        /// Deposit cost
        /// </summary>
        protected int DepositCost { get; set; }

        /// <summary>
        /// Type of account
        /// </summary>
        protected AccountType Type { get; set; }

        /// <summary>
        /// Bonus points
        /// </summary>
        public int Points { get; protected set; }

        /// <summary>
        /// Changes bonus points on deposit
        /// </summary>
        /// <param name="deposit"></param>
        public abstract void OnDeposit(decimal deposit);

        /// <summary>
        /// Changes bonus points on withdraw
        /// </summary>
        /// <param name="withdraw"></param>
        public abstract void OnWithdraw(decimal withdraw);

        /// <summary>
        /// Sets balance cost and deposit cost depending on account type
        /// </summary>
        protected virtual void SetCosts()
        {
            switch (Type)
            {
                case AccountType.Platinum:
                case AccountType.Gold:
                case AccountType.Base:
                    BalanceCost = 0;
                    DepositCost = 0;
                    break;
            }
        }
    }
}
