using UnityEngine;

namespace CharacterControls
{
    public class PlayerCharacterController : BaseCharacterController
    {
        private void OnDestroy()
        {
            InputHandler.onAttackButtonPressed -= InitAttack;
            InputHandler.onJumpButtonPressed -= _movement.Jump;
        }

        protected override void Init()
        {
            base.Init();

            InputHandler.onAttackButtonPressed += InitAttack;
            InputHandler.onJumpButtonPressed += _movement.Jump;
        }

        protected override Vector2 CalculateDirection()
        {
            return Vector2.right * InputHandler.Horizontal;
        }

        protected override void Death()
        {
            base.Death();

            InputHandler.onAttackButtonPressed -= InitAttack;
            InputHandler.onJumpButtonPressed -= _movement.Jump;

            SceneController.ShowDiePanel();
        }
    }
}