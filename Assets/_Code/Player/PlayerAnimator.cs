using UnityEngine;

namespace _Code.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private PlayerMovement _movement;
        [SerializeField] private Animator _animator;

        private const string IsWalkingString = "IsWalking";

        private void Update()
        {
            if (_movement.IsWalking)
                _animator.SetBool(IsWalkingString, true);
            else
                _animator.SetBool(IsWalkingString, false);
        }
    }
}