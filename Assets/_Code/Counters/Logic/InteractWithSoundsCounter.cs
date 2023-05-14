using UnityEngine;

public class InteractWithSoundsCounter : MonoBehaviour
{
    [Header("Fast sound interaction functionality")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _interactSounds;

    protected void PlayInteractionSound()
    {
        int randomIndex = Random.Range(0, _interactSounds.Length);
        AudioClip clip = _interactSounds[randomIndex];
        _audioSource.PlayOneShot(clip);
    }
}