using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField, Header("Settings"), Range(7f, 20f)] private float _rotationSpeed = 5f;
    
    private Vector3 _moveDirectionVec3 => new Vector3(_movement.Movement.x, 0, _movement.Movement.y);

    private void Update()
    {
        if (_movement.IsWalking)
        {
            transform.forward = Vector3.Slerp(transform.forward, _moveDirectionVec3, Time.deltaTime * _rotationSpeed);
        }
    }
}