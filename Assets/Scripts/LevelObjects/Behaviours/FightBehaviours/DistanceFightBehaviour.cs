using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FightBehaviours
{
    public class DistanceFightBehaviour : BaseFightBehaviour
    {
        [SerializeField] float minDistance;
        [SerializeField] float maxDistance;

        protected override bool CheckAttackPossibility()
        {
            if (target == null)
                return false;

            float distance = Vector2.Distance(transform.position, target.position);

            return (distance >= minDistance && distance <= maxDistance);
        }
    }
}

