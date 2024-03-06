using UnityEngine;

namespace MoveBehaviours
{
    public class ChaseBehaviour : MoveBehaviour
    {
        [SerializeField] protected float minDistance, maxDistance;
        protected Transform target;

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        protected override Vector2 GetDirection()
        {
            if (target == null)
                return Vector2.zero;

            Vector2 direction = target.position - transform.position;
            float distance = direction.magnitude - minDistance;

            if (distance >= minDistance && distance <= maxDistance)
                return Vector2.zero;

            return direction;
        }
    }
}

