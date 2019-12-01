using Task2.Domain.BonusSystem.Abstract;

namespace Task2.Domain.BonusSystem
{
    public class DefaultBonusSystem : BonusSystemBase
    {
        /// <summary>
        /// Initials new bonus system
        /// </summary>
        /// <param name="accountType">Type of account</param>
        public DefaultBonusSystem(AccountType accountType = AccountType.Base, decimal balance = 0) : base(accountType)
        {
            Points = (int)balance * BalanceCost;
        }

        /// Changes bonus points on deposit
        /// </summary>
        /// <param name="deposit"></param>
        public override void OnDeposit(decimal deposit)
        {
            Points += (int)deposit * DepositCost;
        }

        /// <summary>
        /// Changes bonus points on withdraw
        /// </summary>
        /// <param name="withdraw"></param>
        public override void OnWithdraw(decimal withdraw)
        {
            Points -= (int)withdraw * DepositCost;
        }

        /// <summary>
        /// Sets balance cost and deposit cost depending on account type
        /// </summary>
        protected override void SetCosts()
        {
            switch (Type)
            {
                case AccountType.Platinum:
                    BalanceCost = 100;
                    DepositCost = 100;
                    break;
                case AccountType.Gold:
                    BalanceCost = 50;
                    DepositCost = 50;
                    break;
                case AccountType.Base:
                    BalanceCost = 10;
                    DepositCost = 10;
                    break;
                default:
                    BalanceCost = 0;
                    DepositCost = 0;
                    break;
            }
        }
    }
}
