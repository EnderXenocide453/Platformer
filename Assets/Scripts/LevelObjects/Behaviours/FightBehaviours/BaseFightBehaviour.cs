using UnityEngine;

namespace FightBehaviours
{
    public abstract class BaseFightBehaviour : MonoBehaviour
    {
        public bool canAttack { get; private set; }
        protected Transform target;

        private bool _stopChecking;

        public delegate void FightBehaviourEventHandler();
        public event FightBehaviourEventHandler onAttackIsPossible;

        private void FixedUpdate()
        {
            if (_stopChecking)
                return;

            canAttack = CheckAttackPossibility();
            if (canAttack) {
                onAttackIsPossible?.Invoke();
            }
        }

        public virtual void SetTarget(Transform target)
        {
            this.target = target;

            _stopChecking = (target == null);
        }

        protected abstract bool CheckAttackPossibility();
    }
}

