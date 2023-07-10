using UnityEngine;
using UnityEngine.UI;

namespace _Code.Minigames.MixerMinigame
{
    public class FoamVisuals : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _firstLevelParticles;
        [SerializeField] private ParticleSystem _secondLevelParticles;
        [SerializeField] private ParticleSystem _thirdLevelParticles;
        [SerializeField] private Image _firstFoamCircle;
        [SerializeField] private Image _secondFoamCircle;
        [SerializeField] private Image _thirdFoamCircle;
        
        public void SetLevel(FoamLevel current)
        {
            switch (current)
            {
                case FoamLevel.One:
                    _firstLevelParticles.gameObject.SetActive(true);
                    _firstFoamCircle.color = Color.cyan;
                    break;
                case FoamLevel.Two:
                    _secondLevelParticles.gameObject.SetActive(true);
                    _secondFoamCircle.color = Color.cyan;
                    break;
                case FoamLevel.Three:
                    _thirdLevelParticles.gameObject.SetActive(true);
                    _thirdFoamCircle.color = Color.cyan;
                    break;
            }
        }
    }
}