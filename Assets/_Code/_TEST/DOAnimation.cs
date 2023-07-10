using DG.Tweening;
using UnityEngine;

namespace _Code._TEST
{
    public static class DOAnimation
    {
        public static Tween Move(Transform transform, float duration, Vector3 position, Ease ease) => 
            transform
                .DOLocalMove(position, duration)
                .SetEase(ease);

        public static Tween ScaleToOne(Transform transform, float duration)
        {
            transform.localScale = Vector3.zero;
            return transform.DOScale(Vector3.one, duration);
        }

        public static Tween ScaleToZero(Transform transform, float duration)
        {
            transform.localScale = Vector3.one;
            return transform.DOScale(Vector3.zero, duration);
        }

        public static Tween FadeIn(CanvasGroup group, float duration) =>
            group.DOFade(1, duration);

        public static Tween FadeOut(CanvasGroup group, float duration) =>
            group.DOFade(0, duration);
    }
}