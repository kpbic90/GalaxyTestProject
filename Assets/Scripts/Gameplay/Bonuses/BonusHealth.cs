using Gameplay.ShipSystems;

namespace Gameplay.Bonuses
{
    public class BonusHealth : IBonus
    {
        protected override void ApplyBonus(IBonus bonus, IBuffable buffable)
        {
            buffable.ApplyBonus<HealthSystem>(bonus);
        }
    }
}