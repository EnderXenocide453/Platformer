using UnityEngine;

namespace MoveBehaviours
{
    class HorizontalChaseBehaviour : ChaseBehaviour
    {
        protected override Vector2 GetDirection()
        {
            if (target == null)
                return Vector2.zero;

            float direction = target.position.x - transform.position.x;
            float distance = Mathf.Abs(direction) - minDistance;

            if (distance >= minDistance && distance <= maxDistance)
                return Vector2.zero;

            return new Vector2(direction * distance, 0);
        }
    }
}
