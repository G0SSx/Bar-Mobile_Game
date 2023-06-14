using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace _Code.Audio
{
    public class AudioSettings
    {
        private readonly AudioMixerGroup _masterGroup;
        private readonly Slider _masterVolumeSlider;

        private const string _masterGroupName = "Master";
        private const string _musicGroupName = "Music";
        private const string _sfxGroupName = "SFX";

        private bool _musicGroupActive = true;
        private bool _sfxGroupActive = true;

        public AudioSettings(AudioMixerGroup masterGroup, Slider masterVolumeSlider)
        {
            _masterGroup = masterGroup;
            _masterVolumeSlider = masterVolumeSlider;
            _masterVolumeSlider.onValueChanged.AddListener(ChangeMasterVolume);
            Load();
        }

        public void Save()
        {
            PlayerPrefs.SetInt(_musicGroupName, _musicGroupActive ? 1 : 0);
            PlayerPrefs.SetInt(_sfxGroupName, _sfxGroupActive ? 1 : 0);
        }

        public void Load()
        {
            _musicGroupActive = PlayerPrefs.GetInt(_musicGroupName) == 1 ? true : false;
            _sfxGroupActive = PlayerPrefs.GetInt(_sfxGroupName) == 1 ? true : false;
        }

        public void ChangeMasterVolume(float value)
        {
            float volume = Mathf.Lerp(-80, 0, value);
            _masterGroup.audioMixer.SetFloat(_masterGroupName, volume);
        }

        public void ToggleMusic()
        {
            _masterGroup.audioMixer.SetFloat(_musicGroupName, _sfxGroupActive ? -80 : 0);
        }

        public void ToggleSFX()
        {
            _masterGroup.audioMixer.SetFloat(_sfxGroupName, _sfxGroupActive ? -80 : 0);
        }
    }
}