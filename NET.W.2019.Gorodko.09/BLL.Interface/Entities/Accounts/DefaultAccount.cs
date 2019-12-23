using BLL.Interface.Entities.Accounts.Abstract;
using BLL.Interface.Entities.BonusSystems.Abstract;

namespace BLL.Interface.Entities.Accounts
{
    /// <inheritdoc/>
    public class DefaultAccount : Account
    {
        /// <summary>
        /// Initials new instance of account.
        /// </summary>
        /// <param name="bonusSystem">Bonus system.</param>
        public DefaultAccount(int id, BonusSystem bonusSystem, bool isClosed = false) : base(id, bonusSystem, isClosed)
        {
        }

        /// <inheritdoc/>
        protected override void AdditionalDepositAction(decimal deposit)
        {
            // No additional actions for default account.
        }

        /// <inheritdoc/>
        protected override void AdditionalWithdrawAction(decimal withdraw)
        {
            // No additional actions for default account.
        }
    }
}
