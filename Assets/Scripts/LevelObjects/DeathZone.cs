using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] LayerMask killMask;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Kill(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Kill(collision);
    }

    private void Kill(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & killMask.value) == 0)
            return;

        if (collision.attachedRigidbody.TryGetComponent<Health>(out var health)) {
            health.TakeDamage(health.currentHealth);
        }

        Destroy(collision.attachedRigidbody.gameObject);
    }
}
