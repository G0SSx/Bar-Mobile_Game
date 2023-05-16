using UnityEngine;

public class GiveSoundCounter : SoundCounter
{
    [SerializeField] private AudioClip[] _giveSounds;

    public void PlayGiveSound()
    {
        int clipIndex = GetRandomSoundIndex(_giveSounds.Length);
        AudioClip clip = _giveSounds[clipIndex];
        audioSource.PlayOneShot(clip);
    }
}