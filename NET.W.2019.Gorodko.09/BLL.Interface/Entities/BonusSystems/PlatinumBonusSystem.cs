using BLL.Interface.Entities.BonusSystems.Abstract;

namespace BLL.Interface.Entities.BonusSystems
{
    /// <inheritdoc/>
    public class PlatinumBonusSystem : BonusSystem
    {
        /// <inheritdoc/>
        protected override int DepositCost => 3;

        /// <inheritdoc/>
        protected override int BalanceCost => 3;
    }
}