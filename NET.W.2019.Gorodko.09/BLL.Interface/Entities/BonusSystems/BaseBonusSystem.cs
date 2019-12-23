using BLL.Interface.Entities.BonusSystems.Abstract;

namespace BLL.Interface.Entities.BonusSystems
{
    public class BaseBonusSystem : BonusSystem
    {
        protected override int DepositCost => 1;

        protected override int BalanceCost => 1;
    }
}
