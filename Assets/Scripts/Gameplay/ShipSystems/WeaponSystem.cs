using System.Collections.Generic;
using Gameplay.Weapons;
using UnityEngine;
using Gameplay.Bonuses;

namespace Gameplay.ShipSystems
{
    public class WeaponSystem : BuffableSystem
    {
        [SerializeField]
        private List<Weapon> _weapons;

        private float AttackSpeed
        {
            get
            {
                var attackSpeed = 1f;

                foreach(var bonus in currentBonuses)
                {
                    attackSpeed += bonus.Value;
                }

                return attackSpeed;
            }
        }

        public void Init(UnitBattleIdentity battleIdentity)
        {
            _weapons.ForEach(w => w.Init(battleIdentity));
        }
                
        public void TriggerFire()
        {
            _weapons.ForEach(w => w.TriggerFire(AttackSpeed));
        }
    }
}
