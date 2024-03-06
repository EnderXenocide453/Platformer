using System.Collections.Generic;
using UnityEngine;

namespace MoveBehaviours
{
    public class WayPoint : MonoBehaviour, IEqualityComparer<WayPoint>
    {
        protected static int wayPointsCount;

        protected int id;

        void Start()
        {
            id = wayPointsCount++;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.attachedRigidbody.TryGetComponent<WayPointMovable>(out var target)) {
                target.OnPointReached(this);
            }
        }

        public bool Equals(WayPoint x, WayPoint y)
        {
            return x.id == y.id;
        }

        public int GetHashCode(WayPoint obj)
        {
            return id;
        }
    }
}

