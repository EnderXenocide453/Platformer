using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterControls
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        private const string xSpeedState = "xSpeed";
        private const string ySpeedState = "ySpeed";
        private const string isGroundState = "isGround";
        private const string attackState = "Attack";
        private const string fallState = "Fall";

        private int _xSpeedState;
        private int _ySpeedState;
        private int _isGroundState;
        private int _attackState;
        private int _fallState;

        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();

            _xSpeedState = Animator.StringToHash(xSpeedState);
            _ySpeedState = Animator.StringToHash(ySpeedState);
            _isGroundState = Animator.StringToHash(isGroundState);
            _attackState = Animator.StringToHash(attackState);
            _fallState = Animator.StringToHash(fallState);
        }

        public void SetSpeed(Vector2 speed)
        {
            _animator.SetFloat(_xSpeedState, speed.x);
            _animator.SetFloat(_ySpeedState, speed.y);

            CalculateFlip(speed.x);
        }

        public void SetGrounded(bool isGrounded)
        {
            _animator.SetBool(_isGroundState, isGrounded);
        }

        public void PlayAttack()
        {
            _animator.SetTrigger(_attackState);
        }

        public void PlayFall()
        {
            _animator.SetTrigger(_fallState);
        }

        private void CalculateFlip(float speed)
        {
            if (Mathf.Abs(speed) < 0.01f)
                return;

            transform.localScale = speed < 0 ? new Vector2(-1, 1) : Vector2.one;
        }
    }
}