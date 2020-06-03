using Gameplay.ShipSystems;

namespace Gameplay.Bonuses
{
    public class BonusAttackSpeed : IBonus
    {
        protected override void ApplyBonus(IBonus bonus, IBuffable buffable)
        {
            buffable.ApplyBonus<WeaponSystem>(bonus);
        }
    }
}