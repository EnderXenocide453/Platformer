using System.Collections;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] protected float damage;

    [SerializeField] float lifeTime = 5;
    [SerializeField] bool destroyOnTimeEnds;
    [SerializeField] bool destroyOnCollision;

    [SerializeField] LayerMask damageMask;

    public virtual void InitDamageDealer(Vector2 direction, LayerMask damageMask)
    {
        transform.localScale = new Vector3(Mathf.Sign(direction.x), 1, 1);
        this.damageMask = damageMask;

        if (destroyOnTimeEnds)
            StartCoroutine(ApplyLifeTime());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleCollision(collision);
    }

    private void HandleCollision(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & damageMask.value) == 0)
            return;

        if (FindHealth(collision, out var targetHealth))
            DealDamage(targetHealth);

        if (destroyOnCollision)
            Destroy(gameObject);
    }

    private bool FindHealth(Collider2D collision, out Health health)
    {
        Rigidbody2D body = collision.attachedRigidbody;
        health = null;
        body?.TryGetComponent(out health);

        return health != null;
    }

    protected virtual void DealDamage(Health health)
    {
        health.TakeDamage(damage);
    }

    private IEnumerator ApplyLifeTime()
    {
        yield return new WaitForFixedUpdate(); //∆дЄм как минимум один fixedUpdate чтобы гарантировано получить коллизии
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
