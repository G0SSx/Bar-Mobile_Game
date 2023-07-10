using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Code._TEST.AnimatedObjects
{
    public class OptionsAnimation : AnimatedUIObject
    {
        [SerializeField] private Button _toggleOptionsButton;
        [SerializeField] private CanvasGroup _group;

        private bool _optionsOpened;

        private void Awake() => 
            _toggleOptionsButton.onClick.AddListener(ToggleOptions);

        private void ToggleOptions()
        {
            if (tween.IsComplete() == false)
                return;

            if (_optionsOpened) Hide();
            else Show();
        }

        public override void Show()
        {
            tween = DOAnimation.Move(transform, Duration, showPosition, Ease.InOutSine);
            DOAnimation.FadeIn(_group, Duration);

            _optionsOpened = true;
        }

        public override void Hide()
        {
            tween = DOAnimation.Move(transform, Duration, hidePosition, Ease.InOutSine);
            DOAnimation.FadeOut(_group, Duration);

            _optionsOpened = false;
        }
    }
}