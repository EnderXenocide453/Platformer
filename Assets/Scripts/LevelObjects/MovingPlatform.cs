using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
public class MovingPlatform : MonoBehaviour
{
    SliderJoint2D _joint;
    float _currentTarget, _nextTarget;

    void Start()
    {
        _joint = GetComponent<SliderJoint2D>();

        _currentTarget = _joint.limits.max;
        _nextTarget = _joint.limits.min;
    }

    private void FixedUpdate()
    {
        if (_joint.useMotor)
            CheckDestination();
    }

    private void CheckDestination()
    {
        if (Mathf.Abs(_joint.jointTranslation - _currentTarget) <= 0.05f)
            ChangeDirection();
    }

    private void ChangeDirection()
    {
        (_currentTarget, _nextTarget) = (_nextTarget, _currentTarget);

        var motor = _joint.motor;
        motor.motorSpeed *= -1;
        _joint.motor = motor;
    }
}
