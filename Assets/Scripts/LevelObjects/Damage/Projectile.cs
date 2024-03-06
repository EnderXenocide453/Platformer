using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
class Projectile : DamageDealer
{
    [SerializeField] float startImpulse;

    public override void InitDamageDealer(Vector2 direction, LayerMask damageMask)
    {
        base.InitDamageDealer(direction, damageMask);
        GetComponent<Rigidbody2D>().velocity = direction * startImpulse;
    }
}
