using UnityEngine;

public abstract class HealthIndicator : MonoBehaviour
{
    [SerializeField] protected Health health;

    void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        if (!health) {
            Destroy(this);
            return;
        }

        health.onHealthChanged += UpdateIndicator;
    }

    protected abstract void UpdateIndicator();
}
