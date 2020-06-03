using System.Collections.Generic;
using Gameplay.Bonuses;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class BuffableSystem : MonoBehaviour
    {
        protected List<IBonus> currentBonuses = new List<IBonus>();

        public virtual void ApplyBonus(IBonus bonus)
        {
            currentBonuses.Add(bonus);
        }

        public void Update()
        {
            for (var i = 0; i < currentBonuses.Count; i++)
            {
                currentBonuses[i].Duration -= Time.deltaTime;

                if (currentBonuses[i].Duration <= 0)
                    currentBonuses.RemoveAt(i);
            }
        }
    }
}