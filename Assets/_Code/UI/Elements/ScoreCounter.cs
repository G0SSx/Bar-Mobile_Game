using UnityEngine;
using Zenject;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private IPersistentProgressService _progress;

    private int _score => _progress.Progress.CurrentScore.Score;

    [Inject]
    private void Construct(IPersistentProgressService progress)
    {
        _progress = progress;
        _progress.Progress.CurrentScore.Changed += UpdateScore;
    }

    private void Start() => 
        UpdateScore();

    private void UpdateScore() =>
        _scoreText.text = $"Score: {_score}";
}