using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace _Code._TEST.AnimatedObjects
{
    public class WindowAnimation : AnimatedUIObject
    {
        [SerializeField] private Button _acceptButton;
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private CardAnimation _card;

        private Vector3 _startPosition;
        private bool _windowOpened;
    
        private void Awake()
        {
            _acceptButton.onClick.AddListener(Hide);
            _startPosition = transform.localPosition;
        }

        private void Update()
        {
            if (tweenComplete && Input.GetKeyDown(KeyCode.W))
                Show();
        }

        public override void Show()
        {
            if (_windowOpened)
                return;

            DOAnimation.FadeIn(_group, Duration);
            DOAnimation.ScaleToOne(transform, Duration);
            tween = DOAnimation.Move(transform, Duration, showPosition, Ease.OutCubic);

            _windowOpened = true;
        }

        public override void Hide()
        {
            DOAnimation.FadeOut(_group, Duration);
            DOAnimation.ScaleToZero(transform, Duration);
            tween = DOAnimation.Move(transform, Duration, hidePosition, Ease.InBack);

            ResetWindowPosition();
            _windowOpened = false;
            _card.Show();
        }

        private void ResetWindowPosition() =>
            transform.position = _startPosition;
    }
}