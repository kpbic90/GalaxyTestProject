using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.Bonuses
{
    public class IBonus : MonoBehaviour
    {
        [SerializeField] private float _duration;

        [SerializeField] private MovementSystem _movementSystem;

        [SerializeField] private float _value;

        public float Value => _value;

        public float Duration
        {
            get => _duration;
            set => _duration = value;
        }

        private void Update()
        {
            _movementSystem.LongitudinalMovement(Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var buffableObject = other.gameObject.GetComponent<IBuffable>();

            if (buffableObject != null)
            {
                ApplyBonus(this, buffableObject);
                Destroy(gameObject);
            }
        }

        protected virtual void ApplyBonus(IBonus bonus, IBuffable buffable)
        {
        }
    }
}