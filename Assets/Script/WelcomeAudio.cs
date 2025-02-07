using UnityEngine;

public class AudioSequenceController : MonoBehaviour
{
    public AudioSource audioSource1; // AudioSource pertama
    public AudioSource audioSource2; // AudioSource kedua

    private void Start()
    {
        if (audioSource1 == null || audioSource2 == null)
        {
            Debug.LogError("AudioSource tidak ditemukan! Pastikan kedua AudioSource telah ditetapkan.");
            return;
        }

        // Mulai pemutaran berurutan
        PlayFirstAudio();
    }

    private void PlayFirstAudio()
    {
        audioSource1.Play();
        Invoke(nameof(PlaySecondAudio), audioSource1.clip.length);
    }

    private void PlaySecondAudio()
    {
        audioSource2.Play();
    }
}
