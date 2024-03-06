using System.Collections.Generic;

namespace Senses
{
    public class SpotedTargetsHandler
    {
        private Dictionary<SenseType, List<SensorTrigger>> _spotedTargets;

        public int targetCount { get; private set; }

        public SpotedTargetsHandler()
        {
            _spotedTargets = new Dictionary<SenseType, List<SensorTrigger>>()
            {
                { SenseType.sight, new List<SensorTrigger>() },
                { SenseType.hearing, new List<SensorTrigger>() }
            };
        }

        public SensorTrigger[] GetTargets(SenseType type) => _spotedTargets[type].ToArray();

        public bool TryAddTarget(SensorTrigger target)
        {
            if (_spotedTargets[target.SenseType].Contains(target))
                return false;

            _spotedTargets[target.SenseType].Add(target);
            targetCount++;
            return true;
        }

        public bool RemoveTarget(SensorTrigger target)
        {
            if (_spotedTargets[target.SenseType].Remove(target)) {
                targetCount--;
                return true;
            }

            return false;
        }
    }
}

