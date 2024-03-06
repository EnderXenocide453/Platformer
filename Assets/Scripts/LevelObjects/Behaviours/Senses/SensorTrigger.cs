using System.Collections.Generic;
using UnityEngine;

namespace Senses
{
    public class SensorTrigger : MonoBehaviour, IEqualityComparer<SensorTrigger>
    {
        static int _count;
        [SerializeField] SenseType sense;
        private int _id;

        public bool CompareSense(SenseType type) => sense == type;
        public SenseType SenseType => sense;

        private void Awake()
        {
            _id = _count++;
        }

        public bool Equals(SensorTrigger x, SensorTrigger y) => x._id == y._id;
        public int GetHashCode(SensorTrigger obj) => obj._id;
    }

    public enum SenseType
    {
        sight,
        hearing
    }
}

