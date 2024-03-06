using UnityEngine;
using UnityEngine.Events;

public class InteractableArea : MonoBehaviour
{
    [SerializeField] LayerMask triggerMask;
    [SerializeField] UnityEvent onTrigger;
    [Space]
    [SerializeField] bool destroyOnTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & triggerMask.value) > 0)
            Trigger();
    }

    private void Trigger()
    {
        onTrigger?.Invoke();

        if (destroyOnTrigger)
            Destroy(gameObject);
    }
}
