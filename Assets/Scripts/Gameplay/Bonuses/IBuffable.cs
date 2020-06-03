using Gameplay.ShipSystems;

namespace Gameplay.Bonuses
{
    public interface IBuffable
    {
        void ApplyBonus<T>(IBonus bonus) where T : BuffableSystem;
    }
}