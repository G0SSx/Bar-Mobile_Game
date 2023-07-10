using UnityEngine;

namespace _Code.Minigames.ShakerMinigame
{
    public class RotatingObject : MonoBehaviour
    {
        [SerializeField, Range(150f, 400f)] private float _speed;
        [SerializeField] private bool _rotateLeft;

        private void Update()
        {
            if (_rotateLeft)
                transform.Rotate(0f, 0f, _speed * Time.deltaTime);
            else
                transform.Rotate(0f, 0f, _speed * Time.deltaTime * -1f);
        }
    }
}