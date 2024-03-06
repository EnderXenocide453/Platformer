using UnityEngine;

namespace CharacterControls
{
    [RequireComponent(typeof(BaseCharacterAttack))]
    [RequireComponent(typeof(CharacterAnimation))]
    [RequireComponent(typeof(Health))]
    public abstract class BaseCharacterController : MonoBehaviour
    {
        protected BaseCharacterMovement _movement;
        protected BaseCharacterAttack _attackController;
        protected CharacterAnimation _animation;
        protected Health _health;

        private void Start()
        {
            Init();
        }

        protected virtual void FixedUpdate()
        {
            _movement.SetDirection(CalculateDirection());

            _animation.SetSpeed(new Vector2(_movement.XSpeed, _movement.YSpeed));
            _animation.SetGrounded(_movement.IsGrounded);
            _attackController.SetDirection(new Vector2(transform.localScale.x, 0));
        }

        protected virtual void Init()
        {
            _movement = GetComponent<BaseCharacterMovement>();
            _attackController = GetComponent<BaseCharacterAttack>();
            _animation = GetComponent<CharacterAnimation>();
            _health = GetComponent<Health>();

            _health.onDeath.AddListener(Death);
        }

        protected virtual void Death()
        {
            _animation.PlayFall();
            _animation.enabled = false;
            _health.enabled = false;
            _attackController.enabled = false;
            _movement.enabled = false;
            enabled = false;
        }

        protected void InitAttack()
        {
            _attackController.InitAttack();
            _animation.PlayAttack();
        }

        protected abstract Vector2 CalculateDirection();
    }
}

