using BLL.Interface.Entities.BonusSystems.Abstract;

namespace BLL.Interface.Entities.BonusSystems
{
    /// <inheritdoc/>
    public class BaseBonusSystem : BonusSystem
    {
        /// <inheritdoc/>
        protected override int DepositCost => 1;

        /// <inheritdoc/>
        protected override int BalanceCost => 1;
    }
}
