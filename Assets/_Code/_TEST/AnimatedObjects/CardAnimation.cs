using DG.Tweening;
using UnityEngine;

namespace _Code._TEST.AnimatedObjects
{
    public class CardAnimation : AnimatedUIObject
    {
        [SerializeField] private CanvasGroup _group;

        private RectTransform _rectTransform;
        private bool _isOpened;

        private void Awake() => 
            _rectTransform = GetComponent<RectTransform>();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T) && tweenComplete)
                ToggleCard();
        }

        private void ToggleCard()
        {
            if (_isOpened) Hide();
            else Show();
        }

        public override void Show()
        {
            DOAnimation.FadeIn(_group, Duration);
            DOAnimation.ScaleToOne(transform, Duration);
            tween = _rectTransform.DOAnchorPos(showPosition, Duration);
        }

        public override void Hide()
        {
            DOAnimation.FadeOut(_group, Duration);
            DOAnimation.ScaleToZero(transform, Duration);
            tween = _rectTransform.DOAnchorPos(hidePosition, Duration);
        }
    }
}