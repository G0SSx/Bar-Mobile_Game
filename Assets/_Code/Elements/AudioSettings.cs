using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _masterVolumeSlider;

    private const string _masterChannel = "Master";
    private const string _musicGroup = "Music";
    private const string _soundsGroup = "Sounds";

    private void Start()
    {
        _masterVolumeSlider.onValueChanged.AddListener(ChangeMasterVolume);
    }

    public void Save()
    {

    }

    public void ChangeMasterVolume(float value)
    {
        float volume = Mathf.Lerp(-80, 0, value);
        _mixer.SetFloat(_masterChannel, volume);
    }

    public void ToggleMusic()
    {

    }

    public void ToggleSounds()
    {

    }
}