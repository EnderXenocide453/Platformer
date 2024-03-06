using UnityEngine;

namespace Senses
{
    /// <summary>
    /// Управляет процессом обнаружения экземпляров SenseObject
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
        /// Вызывается при пересечении сенсора с объектом обнаружения подходящего типа.
        /// Для корректной работы необходим вызов события onDetect
        /// </summary>
        /// <param name="target">Обнаруженный объект</param>
        protected abstract void CheckDetection(SensorTrigger target);
        /// <summary>
        /// Вызывается при окончании пересечения сенсора с объектом обнаружения подходящего типа.
        /// Для корректной работы необходим вызов события onDetectionEnds
        /// </summary>
        /// <param name="target">Обнаруженный объект</param>
        protected abstract void CheckDetectionEnd(SensorTrigger target);
    }
}

