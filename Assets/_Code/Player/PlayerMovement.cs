using _Code.Configs;
using _Code.Extensions;
using _Code.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace _Code.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private PlayerConfig _config;

        private float _moveSpeed;
        private float _movementThreshold;

        public Vector3 MoveDirectionVec3 => new Vector3(Movement.x, transform.position.y, Movement.y);
        public Vector2 Movement {get; private set; }
        public bool IsWalking { get; private set; }

        private IInputService _input;

        [Inject]
        public void Construct(IInputService input) => 
            _input = input;

        private void Awake()
        {
            _moveSpeed = _config.MoveSpeed;
            _movementThreshold = _config.MovementThreashold;
        }

        private void Update()
        {
            Vector2 currentMovement = _input.Axis;
            IsWalking = currentMovement.Greater(_movementThreshold);

            if (IsWalking)
                Movement = currentMovement;
            else
                Movement = Vector2.zero;
        }

        private void FixedUpdate()
        {
            _rigidbody.velocity += _moveSpeed * MoveDirectionVec3;
        }
    }
}