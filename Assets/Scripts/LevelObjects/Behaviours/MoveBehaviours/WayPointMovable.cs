using System.Collections.Generic;
using UnityEngine;

namespace MoveBehaviours
{
    public class WayPointMovable : MoveBehaviour
    {
        [SerializeField] float delay;
        [SerializeField] List<WayPoint> wayPoints;

        public WayPoint CurrentPoint => wayPoints[0];

        private void Start()
        {
            if (wayPoints.Count == 0)
                Destroy(this);
        }

        public void OnPointReached(WayPoint point)
        {
            if (point == CurrentPoint)
                Wait(delay);
        }

        protected override void OnEndWaiting()
        {
            base.OnEndWaiting();

            wayPoints.Add(wayPoints[0]);
            wayPoints.RemoveAt(0);
        }

        protected override Vector2 GetDirection() => (CurrentPoint.transform.position - transform.position).normalized;
    }
}

