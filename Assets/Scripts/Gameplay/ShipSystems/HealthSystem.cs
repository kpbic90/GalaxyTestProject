using System.Collections;
using Gameplay.Bonuses;
using Gameplay.Helpers;
using Gameplay.Weapons;
using UnityEngine;
using UnityEngine.Events;

namespace Gameplay.ShipSystems
{
    public class HealthSystem : BuffableSystem
    {
        [SerializeField] private Animator animator;

        [SerializeField] private int healthPoints;

        [SerializeField] private UnityEvent OnDeathEvent;

        [SerializeField] private UnityEvent OnHealthChangeEvent;

        public int CurrentHealthPoints { get; private set; }

        public void Awake()
        {
            CurrentHealthPoints = healthPoints;
        }

        public void GetHit(IDamageDealer damageDealer)
        {
            CurrentHealthPoints -= (int) damageDealer.Damage;
            OnHealthChangeEvent.Invoke();

            if (CurrentHealthPoints <= 0)
            {
                OnDeathEvent.Invoke();

                if (animator)
                {
                    animator.SetTrigger("death");
                    StartCoroutine(WaitToKill());
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

        private IEnumerator WaitToKill()
        {
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);
        }

        public void EndGame()
        {
            GameController.Instance.ShowEndGameWindow();
        }

        public override void ApplyBonus(IBonus bonus)
        {
            CurrentHealthPoints = Mathf.Min(healthPoints, CurrentHealthPoints + (int) bonus.Value);
            OnHealthChangeEvent.Invoke();
        }
    }
}