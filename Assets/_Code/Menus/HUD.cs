using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _timerText;

    public void ResetHud() => 
        _scoreText.text = "Score: 0";

    public void UpdateTimer(float timeInSec)
    {
        if (timeInSec <= 0)
        {
            _timerText.text = $"{0}:{00}";
            return;
        }

        /*int mins = Mathf.FloorToInt(timeInSec / IngameSettings.SecondsInMinute);
        int secs = Mathf.FloorToInt(timeInSec - (mins * IngameSettings.SecondsInMinute));*/

        _timerText.text = $"{0}:{00}";
    }

    public void UpdateScore(int score) => 
        _scoreText.text = $"Score: {score}";
}