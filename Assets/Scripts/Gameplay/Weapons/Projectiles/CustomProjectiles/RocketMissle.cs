using Gameplay.Weapons.Projectiles;
using UnityEngine;

public class RocketMissle : Projectile
{
    private float acceleration = 0.25f;
    private readonly float accelerationPower = 0.5f;

    protected override void Move(float speed)
    {
        transform.Translate(acceleration * speed * Time.deltaTime * Vector3.up);
        acceleration += Time.deltaTime * accelerationPower;
    }
}