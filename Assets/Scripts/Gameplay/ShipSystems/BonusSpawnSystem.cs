using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class BonusSpawnSystem : MonoBehaviour
    {
        [SerializeField] private float _chance;

        [SerializeField] private List<GameObject> prefabBonusList;

        public void TrySpawnBonus()
        {
            if (Random.Range(0f, 1f) <= _chance)
                Instantiate(prefabBonusList[Random.Range(0, prefabBonusList.Count)], transform.position,
                    transform.rotation, transform.parent);
        }
    }
}