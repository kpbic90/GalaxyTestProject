using System.Collections.Generic;
using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.UI
{
    public class HealthRenderer : MonoBehaviour
    {
        [SerializeField] private HealthSystem _healthSystem;

        private readonly List<HealthPointRenderer> healthPointRenderers = new List<HealthPointRenderer>();

        [SerializeField] private GameObject healthPointsHolder;

        [SerializeField] private GameObject prefabHealthPoint;

        public void Start()
        {
            InitHealth(_healthSystem.CurrentHealthPoints);
        }

        private void InitHealth(int maxHealth)
        {
            while (healthPointsHolder.transform.childCount > 0)
                DestroyImmediate(healthPointsHolder.transform.GetChild(0).gameObject);

            for (var i = 0; i < maxHealth; i++)
            {
                var healthPoint = Instantiate(prefabHealthPoint, healthPointsHolder.transform);
                healthPoint.transform.localPosition = new Vector3(-((float) maxHealth - 1) / 2 + i, 0, 0);
                healthPointRenderers.Add(healthPoint.GetComponent<HealthPointRenderer>());
            }
        }

        public void UpdateHealth()
        {
            for (var i = 0; i < healthPointRenderers.Count; i++)
                healthPointRenderers[i].PopHealth(i < _healthSystem.CurrentHealthPoints);
        }
    }
}