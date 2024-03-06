using UnityEngine;
using Senses;
using MoveBehaviours;
using System.Collections.Generic;
using FightBehaviours;

namespace CharacterControls
{
    public abstract class AICharacterController : BaseCharacterController
    {
        [SerializeField] protected MoveBehaviour idleBehaviour;
        [SerializeField] protected ChaseBehaviour chaseBehaviour;
        [Space]
        [SerializeField] protected BaseFightBehaviour fightBehaviour;

        protected SpotedTargetsHandler spotedTargets;
        protected MoveBehaviour currentBehaviour;

        protected HashSet<SenseType> senseTypes;

        private Sensor[] _sensors;

        protected override void Init()
        {
            base.Init();

            if (fightBehaviour == null)
                fightBehaviour = GetComponent<FightBehaviours.BaseFightBehaviour>();

            ConnectSensors();

            currentBehaviour = idleBehaviour;
            spotedTargets = new SpotedTargetsHandler();

            fightBehaviour.onAttackIsPossible += TryAttack;
            _attackController.onAttackIsPossible += TryAttack;
        }

        private void ConnectSensors()
        {
            _sensors = GetComponentsInChildren<Sensor>(includeInactive: true);
            senseTypes = new HashSet<SenseType>();

            foreach (var sensor in _sensors)
                ConnectSensor(sensor);
        }

        private void ConnectSensor(Sensor sensor)
        {
            sensor.onDetect += Detect;
            sensor.onDetectionEnds += Lost;

            senseTypes.Add(sensor.SenseType);
        }

        private void Detect(SensorTrigger target)
        {
            spotedTargets.TryAddTarget(target);
            OnDetected(target);
        }

        private void Lost(SensorTrigger target)
        {
            spotedTargets.RemoveTarget(target);
            OnDetectionEnds(target);

            if (spotedTargets.targetCount == 0)
                OnAllDetectionsEnds();
        }

        protected abstract void OnDetected(SensorTrigger target);
        protected abstract void OnDetectionEnds(SensorTrigger target);
        protected abstract void OnAllDetectionsEnds();

        private void TryAttack()
        {
            if (fightBehaviour.canAttack && _attackController.canAttack)
                InitAttack();
        }

        protected override Vector2 CalculateDirection()
        {
            return currentBehaviour.Direction;
        }
    }
}