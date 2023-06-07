using UnityEngine;
using Zenject;
using TMPro;

public class BalanceCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private IPersistentProgressService _progress;

    private int _money => _progress.Progress.Money.Money;

    [Inject]
    private void Construct(IPersistentProgressService progress)
    {
        _progress = progress;
        _progress.Progress.Money.Changed += UpdateScore;
    }

    private void Start() => 
        UpdateScore();

    private void UpdateScore() =>
        _text.text = $"Balance: {_money}";
}