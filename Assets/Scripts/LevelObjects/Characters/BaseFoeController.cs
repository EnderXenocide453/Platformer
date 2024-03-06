using Senses;
using UnityEngine;

namespace CharacterControls
{
    public class BaseFoeController : AICharacterController
    {
        private SensorTrigger _currentTarget;

        protected override void FixedUpdate()
        {
            base.FixedUpdate();

            _currentTarget = CalculateNearestTarget();

            chaseBehaviour.SetTarget(_currentTarget?.transform);
            fightBehaviour.SetTarget(_currentTarget?.transform);
        }

        protected override void OnDetected(SensorTrigger target)
        {
            currentBehaviour = chaseBehaviour;
        }

        protected override void OnDetectionEnds(SensorTrigger target) { }

        protected override void OnAllDetectionsEnds()
        {
            currentBehaviour = idleBehaviour;
        }

        protected SensorTrigger CalculateNearestTarget()
        {
            var senses = new SenseType[senseTypes.Count];
            senseTypes.CopyTo(senses);

            return CalculateNearestTarget(senses);
        }

        protected SensorTrigger CalculateNearestTarget(params SenseType[] types)
        {
            float minDistance = float.MaxValue;
            SensorTrigger newTarget = null;

            foreach (var type in types) {
                var targets = spotedTargets.GetTargets(type);

                if (targets.Length == 0) {
                    continue;
                }

                foreach (var target in targets) {
                    float currentDistance = Mathf.Abs(target.transform.position.x - transform.position.x);

                    if (currentDistance < minDistance) {
                        minDistance = currentDistance;
                        newTarget = target;
                    }
                }
            }

            return newTarget;
        }
    }
}