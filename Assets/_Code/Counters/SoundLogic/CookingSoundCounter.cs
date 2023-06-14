using UnityEngine;

namespace _Code.Counters.SoundLogic
{
    public class CookingSoundCounter : TakeAndGiveSoundCounter
    {
        [SerializeField] private AudioClip[] _interactionSounds;

        public void PlayInteractionSound()
        {
            int clipIndex = GetRandomSoundIndex(_interactionSounds.Length);
            AudioClip clip = _interactionSounds[clipIndex];
            audioSource.PlayOneShot(clip);
        }

        public void StartInteractionSound()
        {
            int clipIndex = GetRandomSoundIndex(_interactionSounds.Length);
            audioSource.clip = _interactionSounds[clipIndex];
            audioSource.loop = true;
            audioSource.Play();
        }

        public void StopInteractionSound()
        {
            audioSource.Stop();
        }
    }
}