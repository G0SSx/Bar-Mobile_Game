using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Code._TEST.AnimatedObjects
{
    public class BalanceText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private Coroutine _balanceCoroutine;
        private int _balance;

        private void Update()
        {
            if (_balanceCoroutine == null && Input.GetKeyDown(KeyCode.B))
                _balanceCoroutine = StartCoroutine(TextBounceAnimation());
        }

        private IEnumerator TextBounceAnimation()
        {
            const float Duration = 0.15f;

            _balance++;
            _text.text = $"Balance: {_balance}";
            _text.transform.DOScale(1.1f, Duration).SetInverted(true);

            yield return new WaitForSeconds(Duration);
            _balanceCoroutine = null;
        }
    }
}