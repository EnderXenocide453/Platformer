using UnityEngine;

namespace MoveBehaviours
{
    public class HorizontalWayPointMovable : WayPointMovable
    {
        protected override Vector2 GetDirection()
        {
            Debug.Log("Its work");
            return new Vector2((CurrentPoint.transform.position - transform.position).x, 0).normalized;
        }
    }
}

