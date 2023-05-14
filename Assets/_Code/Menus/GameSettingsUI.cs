using System;
using TMPro;
using UnityEngine;

public class GameSettingsUI : MonoBehaviour
{
    public Action GameStarted;

    [SerializeField] private GameObject _tutorialStep;
    [SerializeField] private GameObject _settingsStep;
    [SerializeField] private TextMeshProUGUI _timeText;

    private bool _tutorialStepActive => _tutorialStep.activeSelf;

    public void ResetUI()
    {
        _tutorialStep.SetActive(true);
        _settingsStep.SetActive(false);
    }

    public void ToggleSettingSteps()
    {
        _settingsStep.SetActive(_tutorialStepActive);
        _tutorialStep.SetActive(!_tutorialStepActive);
    }

    public void UpdateTimeText(float time)
    {
        if (_tutorialStepActive)
            return;

        _timeText.text = $"{time / IngameSettings.SecondsInMinute} mins";
    }

    public void StartGame()
    {
        GameStarted?.Invoke();
    }
}