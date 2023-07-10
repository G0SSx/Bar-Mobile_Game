using DG.Tweening;
using UnityEngine;

namespace _Code._TEST
{
    public abstract class AnimatedUIObject : MonoBehaviour
    {
        [SerializeField] protected Vector2 hidePosition;
        [SerializeField] protected Vector2 showPosition;
        [SerializeField, Range(0.1f, 1.5f)] private float _duration;

        protected Tween tween;

        protected bool tweenComplete => tween == null || tween.IsComplete();

        public float Duration => _duration;

        public abstract void Show();

        public abstract void Hide();
    }
}