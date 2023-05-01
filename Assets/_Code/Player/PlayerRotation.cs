using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;
    [SerializeField, Header("Settings"), Range(7f, 20f)] private float _rotationSpeed = 5f;
    
    private void Update()
    {
        if (_movement.IsWalking)
            transform.forward = Vector3.Slerp(transform.forward, _movement.MoveDirectionVec3,
                Time.deltaTime * _rotationSpeed);
    }
}