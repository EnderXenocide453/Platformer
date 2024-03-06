using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousDamageDealer : DamageDealer
{
    [SerializeField] float delay;

    Dictionary<int, Coroutine> _currentTargetsCoroutines;

    private void Start()
    {
        _currentTargetsCoroutines = new Dictionary<int, Coroutine>();
    }

    protected override void DealDamage(Health health)
    {
        int id = health.gameObject.GetInstanceID();

        if (_currentTargetsCoroutines.ContainsKey(id))
            return;

        var coroutine = StartCoroutine(DealContinuousDamage(health));
        _currentTargetsCoroutines.Add(id, coroutine);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        int id = collision.collider.attachedRigidbody.gameObject.GetInstanceID();

        if (!_currentTargetsCoroutines.ContainsKey(id))
            return;

        StopCoroutine(_currentTargetsCoroutines[id]);
        _currentTargetsCoroutines.Remove(id);
    }

    private IEnumerator DealContinuousDamage(Health health)
    {
        while (true) {
            health.TakeDamage(damage);
            yield return new WaitForSeconds(delay);
        }
    }
}
