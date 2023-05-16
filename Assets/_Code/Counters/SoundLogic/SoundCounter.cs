using UnityEngine;

public class SoundCounter : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;

    public int GetRandomSoundIndex(int ClipsCountLength)
    {
        return Random.Range(0, ClipsCountLength);
    }
}