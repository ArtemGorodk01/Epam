using BLL.Interface.Entities.BonusSystems.Abstract;

namespace BLL.Interface.Entities.BonusSystems
{
    /// <inheritdoc/>
    public class GoldBonusSystem : BonusSystem
    {
        /// <inheritdoc/>
        protected override int DepositCost => 2;

        /// <inheritdoc/>
        protected override int BalanceCost => 2;
    }
}
