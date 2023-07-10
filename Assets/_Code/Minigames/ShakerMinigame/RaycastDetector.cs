using UnityEngine;

namespace _Code.Minigames.ShakerMinigame
{
    public class RaycastDetector : MonoBehaviour
    {
        [SerializeField] private LayerMask _detectable;

        public bool DetectTarget()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, _detectable);

            if (hit.collider != null)
                return true;

            return false;
        }
    }
}