using Gameplay.Bonuses;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using Gameplay.Weapons;
using UnityEngine;

namespace Gameplay.Spaceships
{
    public class Spaceship : MonoBehaviour, ISpaceship, IDamagable, IBuffable
    {
        [SerializeField]
        private ShipController _shipController;
    
        [SerializeField]
        private MovementSystem _movementSystem;
    
        [SerializeField]
        private WeaponSystem _weaponSystem;

        [SerializeField]
        private HealthSystem _healthSystem;

        [SerializeField]
        private UnitBattleIdentity _battleIdentity;

        public MovementSystem MovementSystem => _movementSystem;
        public WeaponSystem WeaponSystem => _weaponSystem;
        public UnitBattleIdentity BattleIdentity => _battleIdentity;

        private void Start()
        {
            _shipController.Init(this);
            _weaponSystem.Init(_battleIdentity);
        }

        public void StopAllSystems()
        {
            _movementSystem.enabled = false;
            _weaponSystem.enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }

        public void ApplyDamage(IDamageDealer damageDealer)
        {
            _healthSystem.GetHit(damageDealer);
        }

        public void ApplyBonus<T>(IBonus bonus) where T : BuffableSystem
        {
            GetComponent<T>().ApplyBonus(bonus);
        }
    }
}
