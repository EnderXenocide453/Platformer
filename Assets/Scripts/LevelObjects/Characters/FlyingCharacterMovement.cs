using System.Collections;
using UnityEngine;

namespace CharacterControls
{
    public class FlyingCharacterMovement : BaseCharacterMovement
    {
        [SerializeField] float jumpCooldown = 0.5f;

        private bool _canJump = true;

        public override bool IsGrounded => _canJump;

        public override void Jump()
        {
            base.Jump();

            StartCoroutine(InitJump());
        }

        protected override void Move()
        {
            base.Move();

            if (_direction.y > 0)
                Jump();
        }

        protected override void CheckGrounded()
        {
            return;
        }

        private IEnumerator InitJump()
        {
            Debug.Log("jump");
            _canJump = false;
            yield return new WaitForSeconds(jumpCooldown);
            _canJump = true;
        }
    }
}

