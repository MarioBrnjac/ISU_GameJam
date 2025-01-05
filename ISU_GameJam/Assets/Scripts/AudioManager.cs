using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Play audio when the scene starts
        audioSource.Play();
    }

    // Example method to play audio on command
    public void PlayAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // Example method to stop audio
    public void StopAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
