using UnityEngine;
using UnityEngine.UI;

namespace _Code.Minigames.ShakerMinigame
{
    public class ShakerMinigameManager
    {
        [SerializeField] private RaycastDetector _detector;
        [SerializeField] private Button _interactionButton;
        
        private int _score;

        private void HandlePlayerInput() => 
            _score = _detector.DetectTarget() ? 1 : 0;
    }
}