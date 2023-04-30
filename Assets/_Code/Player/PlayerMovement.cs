using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField, Header("Settings"), Range(1f, 5f)] private float _moveSpeed;
    [SerializeField, Range(0f, 0.5f)] private float _movementThreshold = 0.1f;

    public Vector2 Movement {get; private set; }
    public bool IsWalking { get; private set; }

    private InputActions _input;

    [Inject]
    private void Construct(InputActions input) => 
        _input = input;

    private void Update()
    {
        Vector2 currentMovement = _input.Player.Walking.ReadValue<Vector2>();
        IsWalking = currentMovement.Greater(_movementThreshold);

        if (IsWalking)
            Movement = currentMovement;
        else
            Movement = Vector2.zero;
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Movement.x, transform.position.y, Movement.y);
        _rigidbody.velocity += _moveSpeed * moveDirection;
    }
}