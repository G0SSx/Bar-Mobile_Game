using UnityEngine;

public class TakeAndGiveSoundCounter : GiveSoundCounter
{
    [SerializeField] private AudioClip[] _takeSounds;

    public void PlayTakeSound()
    {
        int clipIndex = GetRandomSoundIndex(_takeSounds.Length);
        AudioClip clip = _takeSounds[clipIndex];
        audioSource.PlayOneShot(clip);
    }
}