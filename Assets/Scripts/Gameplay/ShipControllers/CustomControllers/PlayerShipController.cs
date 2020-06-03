using Gameplay.Helpers;
using Gameplay.ShipSystems;
using UnityEngine;

namespace Gameplay.ShipControllers.CustomControllers
{
    public class PlayerShipController : ShipController
    {
        [SerializeField]
        private SpriteRenderer _representation;

        private Vector3 lastPosition;

        private InputStrategy inputStrategy = new KeyboardInputStrategy();

        protected override void ProcessHandling(MovementSystem movementSystem)
        {
            

            var move = new Vector3(inputStrategy.GetHorizontalMove(Camera.main.WorldToScreenPoint(transform.position).x) * Time.deltaTime, 0, 0);

            if (GameAreaHelper.IsInGameplayAreaFull(transform, _representation.bounds))
            {
                lastPosition = transform.position;
                movementSystem.LateralMovement(move.x);                
            }
            else
            {
                transform.position = lastPosition;
            }

            if(inputStrategy.IsStrategySwitchedPressed(out InputStrategy newStrategy))
            {
                inputStrategy = newStrategy;
            }
        }

        protected override void ProcessFire(WeaponSystem fireSystem)
        {
            if (inputStrategy.IsFirePressed())
            {
                fireSystem.TriggerFire();
            }
        }
    }
}
