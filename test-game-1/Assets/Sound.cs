using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource

    void Start()
    {
        // Play the assigned audio clip when the game starts
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource is not assigned!");
        }
    }
}
