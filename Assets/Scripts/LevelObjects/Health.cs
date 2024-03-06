using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth = 100;
    public UnityEvent onDeath;

    public float currentHealth { get; private set; }
    public bool isDead { get; private set; }

    public float MaxHealth => maxHealth;

    public delegate void HealthEventHandler();
    public event HealthEventHandler onHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (isDead)
            return;

        SetHP(currentHealth - damage);
    }

    private void SetHP(float amount)
    {
        currentHealth = Mathf.Clamp(amount, 0, maxHealth);

        onHealthChanged?.Invoke();

        if (currentHealth <= 0) {
            Death();
        }
    }

    private void Death()
    {
        isDead = true;
        onDeath?.Invoke();
    }
}
