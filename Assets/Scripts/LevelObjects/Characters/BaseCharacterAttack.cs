using System.Collections;
using UnityEngine;

namespace CharacterControls
{
    [RequireComponent(typeof(DamageSource))]
    public class BaseCharacterAttack : MonoBehaviour
    {
        [SerializeField] float coolDown = 1;

        public bool canAttack { get; private set; } = true;

        Vector2 _direction;
        DamageSource _damageSource;

        public delegate void AttackEventHandler();
        public event AttackEventHandler onAttackIsPossible;

        private void Start()
        {
            Init();
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public void InitAttack()
        {
            if (!canAttack)
                return;

            StartCoroutine(Cooldown());
        }

        /// <summary>
        /// Вызывается из аниматора
        /// </summary>
        public void Attack()
        {
            _damageSource.InitAttack(_direction.normalized);
        }

        private void Init()
        {
            _damageSource = GetComponent<DamageSource>();
        }

        private IEnumerator Cooldown()
        {
            canAttack = false;
            yield return new WaitForSeconds(coolDown);
            canAttack = true;

            onAttackIsPossible?.Invoke();
        }
    }
}