using UnityEngine;

[RequireComponent(typeof(Health))]
public class DestructableObject : MonoBehaviour
{
    Health _health;

    private void Start()
    {
        _health = GetComponent<Health>();
        _health.onDeath.AddListener(Destruct);
    }

    private void Destruct()
    {
        Destroy(gameObject);
    }
}
