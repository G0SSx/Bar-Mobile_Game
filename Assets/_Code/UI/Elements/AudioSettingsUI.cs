using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettingsUI : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _masterGroup;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Button _musicButton;
    [SerializeField] private Button _sfxButton;

    private AudioSettings _audioSettings;

    private void Awake()
    {
        _audioSettings = new AudioSettings(_masterGroup, _masterVolumeSlider);

        _musicButton.onClick.AddListener(() => _audioSettings.ToggleMusic());
        _sfxButton.onClick.AddListener(() => _audioSettings.ToggleSFX());
    }

    public void ShowSettings() => 
        gameObject.SetActive(true);

    public void HideSettings()
    {
        _audioSettings.Save();
        gameObject.SetActive(false);
    }
}