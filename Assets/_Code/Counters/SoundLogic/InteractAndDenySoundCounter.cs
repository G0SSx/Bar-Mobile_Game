using UnityEngine;

public class InteractAndDenySoundCounter : SoundCounter
{
    [SerializeField] private AudioClip[] _interactSounds;
    [SerializeField] private AudioClip[] _denySounds;

    public void PlayInteractSound()
    {
        int clipIndex = GetRandomSoundIndex(_interactSounds.Length);
        AudioClip clip = _interactSounds[clipIndex];
        audioSource.PlayOneShot(clip);
    }

    public void PlayDenySound()
    {
        int clipIndex = GetRandomSoundIndex(_denySounds.Length);
        AudioClip clip = _denySounds[clipIndex];
        audioSource.PlayOneShot(clip);
    }
}