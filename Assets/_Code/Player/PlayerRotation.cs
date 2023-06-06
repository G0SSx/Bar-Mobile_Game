using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerConfig _config;

    private float _rotationSpeed;

    private void Awake() => 
        _rotationSpeed = _config.RotationSpeed;

    private void Update()
    {
        if (_movement.IsWalking)
            transform.forward = Vector3.Slerp(transform.forward, _movement.MoveDirectionVec3,
                Time.deltaTime * _rotationSpeed);
    }
}