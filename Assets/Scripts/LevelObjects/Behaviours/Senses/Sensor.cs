using UnityEngine;

namespace Senses
{
    /// <summary>
    /// ��������� ��������� ����������� ����������� SenseObject
    /// </summary>
    public abstract class Sensor : MonoBehaviour
    {
        [SerializeField] protected SenseType senseType;

        public SenseType SenseType => senseType;

        public delegate void SenseEventHandler(SensorTrigger target);
        public event SenseEventHandler onDetect;
        public event SenseEventHandler onDetectionEnds;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (TryGetSenseObject(collision, out var senseObject))
                CheckDetection(senseObject);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (TryGetSenseObject(collision, out var senseObject))
                CheckDetectionEnd(senseObject);
        }

        private bool TryGetSenseObject(Behaviour target, out SensorTrigger senseObject)
        {
            senseObject = null;

            if (target.TryGetComponent<SensorTrigger>(out senseObject))
                return senseObject.CompareSense(senseType);

            return false;
        }

        protected void OnDetect(SensorTrigger target) => onDetect?.Invoke(target);
        protected void OnDetectionEnds(SensorTrigger target) => onDetectionEnds?.Invoke(target);

        /// <summary>
        /// ���������� ��� ����������� ������� � �������� ����������� ����������� ����.
        /// ��� ���������� ������ ��������� ����� ������� onDetect
        /// </summary>
        /// <param name="target">������������ ������</param>
        protected abstract void CheckDetection(SensorTrigger target);
        /// <summary>
        /// ���������� ��� ��������� ����������� ������� � �������� ����������� ����������� ����.
        /// ��� ���������� ������ ��������� ����� ������� onDetectionEnds
        /// </summary>
        /// <param name="target">������������ ������</param>
        protected abstract void CheckDetectionEnd(SensorTrigger target);
    }
}

