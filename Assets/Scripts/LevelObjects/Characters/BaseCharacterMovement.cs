using UnityEngine;

namespace CharacterControls
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BaseCharacterMovement : MonoBehaviour
    {
        [Header("Movement params")]
        [SerializeField] protected float speed;
        [SerializeField] protected float jumpForce;

        [Header("GroundTrigger")]
        [SerializeField] protected Collider2D groundTrigger;
        [SerializeField] protected LayerMask groundMask;

        protected Vector2 _direction;
        protected bool _isGrounded = false;

        protected Rigidbody2D _body;

        public virtual float XSpeed => _direction.x;
        public virtual float YSpeed => _body.velocity.y;
        public virtual bool IsGrounded => _isGrounded;

        protected virtual void Start()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            CheckGrounded();
            Move();
        }

        public virtual void Jump()
        {
            if (!enabled || !IsGrounded)
                return;

            _body.velocity = new Vector2(_body.velocity.x, jumpForce);
        }

        public virtual void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        protected virtual void Move()
        {
            _body.velocity = new Vector2(_direction.x * speed, _body.velocity.y);
        }

        protected virtual void CheckGrounded()
        {
            _isGrounded = groundTrigger.IsTouchingLayers(groundMask);
        }
    }
}