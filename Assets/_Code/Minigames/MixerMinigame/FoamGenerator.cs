using UnityEngine.UI;
using UnityEngine;

namespace _Code.Minigames.MixerMinigame
{
    public class FoamGenerator : MonoBehaviour
    {
        [SerializeField] private FoamVisuals _visuals;
        [SerializeField] private Image _slider;
        [SerializeField] private Button _interactionButton;
        
        private const float FirstLevelProgress = 0.15f;
        private const float SecondLevelProgress = 0.5f;
        private const float ThirdLevelProgress = 0.85f;
        private const float DecreaseAmount = 0.1f;
        private const float ProgressPerClick = 0.04f;

        private FoamLevel _level;
        private float _levelProgress;
        private float _progress;
        private float _timer;

        private void Start() => 
            _interactionButton.onClick.AddListener(OnClick);

        private void Update()
        {
            DecreaseProgress();
            UpdateFillIndicator();
            UpdateVisuals();
        }

        private void OnClick() => 
            _progress += ProgressPerClick;

        private void DecreaseProgress()
        {
            float frameLooseAmount = DecreaseAmount * Time.deltaTime;
            float progressNextFrameAmount = _progress - frameLooseAmount;

            if (progressNextFrameAmount <= _levelProgress)
                _progress = _levelProgress;
            else if (progressNextFrameAmount < 0)
                _progress = 0;
            else
                _progress -= frameLooseAmount;
        }

        private void UpdateFillIndicator() => 
            _slider.fillAmount = _progress;
        
        private void UpdateVisuals()
        {
            switch (_progress)
            {
                case >= ThirdLevelProgress:
                    _level = FoamLevel.Three;
                    _visuals.SetLevel(_level);
                    _levelProgress = ThirdLevelProgress;
                    break;
                case >= SecondLevelProgress:
                    _level = FoamLevel.Two;
                    _visuals.SetLevel(_level);
                    _levelProgress = SecondLevelProgress;
                    break;
                case >= FirstLevelProgress:
                    _level = FoamLevel.One;
                    _visuals.SetLevel(_level);
                    _levelProgress = FirstLevelProgress;
                    break;
                default:
                    _level = FoamLevel.Zero;
                    _visuals.SetLevel(_level);
                    break;
            }
        }
    }
}