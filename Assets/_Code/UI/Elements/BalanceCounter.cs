using UnityEngine;
using DG.Tweening;
using Zenject;
using TMPro;

public class BalanceCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    [Header("Balance changed animation settings")]
    [SerializeField] private float _duration = 0.3f;
    [SerializeField] private float _scaleAmount = 1.1f;

    private IPersistentProgressService _progress;

    private int _money => _progress.Progress.Balance.Money;

    [Inject]
    private void Construct(IPersistentProgressService progress)
    {
        _progress = progress;
        _progress.Progress.Balance.Changed += UpdateScore;
    }

    private void Start() => 
        UpdateScore();

    private void UpdateScore()
    {
        _text.text = $"Balance: {_money}";
        PlayBalanceChangedAnimation();
    }

    private void PlayBalanceChangedAnimation()
    {
        transform
            .DOScale(_scaleAmount, _duration)
            .SetInverted(true);
    }
}