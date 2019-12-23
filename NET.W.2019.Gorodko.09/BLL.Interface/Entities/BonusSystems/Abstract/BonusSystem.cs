using System;

namespace BLL.Interface.Entities.BonusSystems.Abstract
{
    /// <summary>
    /// Provides working with bonus system.
    /// </summary>
    public abstract class BonusSystem
    {
        /// <summary>
        /// Gets bonuses.
        /// </summary>
        public int Bonuses { get; private set; }

        /// <summary>
        /// Gets deposit cost.
        /// </summary>
        protected abstract int DepositCost { get; }

        /// <summary>
        /// Gets balance cost.
        /// </summary>
        protected abstract int BalanceCost { get; }

        /// <summary>
        /// Changes bonuses on withdraw.
        /// </summary>
        /// <param name="withdraw">Withdraw.</param>
        public void OnWithdraw(decimal withdraw)
        {
            if (withdraw < 0)
            {
                throw new ArgumentException("Withdraw must be positive.");
            }

            this.Bonuses -= this.BalanceCost * (int)withdraw;
        }

        /// <summary>
        /// Changes bonuses on deposit.
        /// </summary>
        /// <param name="deposit">Deposit.</param>
        public void OnDeposit(decimal deposit)
        {
            if (deposit < 0)
            {
                throw new ArgumentException("deposit must be positive.");
            }

            this.Bonuses += this.DepositCost * (int)deposit;
        }
    }
}
