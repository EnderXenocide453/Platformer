namespace Senses
{
    public class InstantSensor : Sensor
    {
        protected override void CheckDetection(SensorTrigger target)
        {
            OnDetect(target);
        }

        protected override void CheckDetectionEnd(SensorTrigger target)
        {
            OnDetectionEnds(target);
        }
    }
}

