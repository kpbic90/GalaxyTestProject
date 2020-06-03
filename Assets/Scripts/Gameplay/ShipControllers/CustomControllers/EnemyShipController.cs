using System.Collections;
using Gameplay.ShipControllers;
using Gameplay.ShipSystems;
using UnityEngine;

public class EnemyShipController : ShipController
{

    [SerializeField]
    private Vector2 _fireDelay;

    [SerializeField]
    private MovementBehaviour _movementBehaviour;

    private bool _fire = true;
    
    protected override void ProcessHandling(MovementSystem movementSystem)
    {
        switch(_movementBehaviour)
        {
            case MovementBehaviour.Linear:
                movementSystem.LongitudinalMovement(Time.deltaTime);
                break;

            case MovementBehaviour.Sinusoid:
                movementSystem.LongitudinalMovement(Time.deltaTime);
                movementSystem.LateralMovement((float)Mathf.Sin(transform.position.y));
                break;

            case MovementBehaviour.Random:
                movementSystem.LongitudinalMovement(Time.deltaTime);
                movementSystem.LateralMovement(Random.Range(-1,2) * Time.deltaTime);
                break;
        }
    }

    protected override void ProcessFire(WeaponSystem fireSystem)
    {
        if (!_fire)
            return;

        fireSystem.TriggerFire();
        StartCoroutine(FireDelay(Random.Range(_fireDelay.x, _fireDelay.y)));
    }

    private IEnumerator FireDelay(float delay)
    {
        _fire = false;
        yield return new WaitForSeconds(delay);
        _fire = true;
    }

    public enum MovementBehaviour
    {
        Linear = 0,
        Sinusoid = 1,
        Random = 2,
    }
}
