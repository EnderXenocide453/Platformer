using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] GameObject damageDealerPrefab;
    [SerializeField] Transform damagePoint;
    [SerializeField] LayerMask damageMask;

    public void InitAttack(Vector2 direction)
    {
        var damageDealer = Instantiate(damageDealerPrefab, damagePoint.position, Quaternion.identity).GetComponent<DamageDealer>();
        damageDealer.gameObject.SetActive(true);
        damageDealer.InitDamageDealer(direction, damageMask);
    }
}
