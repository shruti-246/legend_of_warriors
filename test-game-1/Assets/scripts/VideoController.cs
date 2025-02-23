using UnityEngine;
using UnityEngine.Video; // Make sure to include this namespace
using UnityEngine.UI; // Include this for Button

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer
    public Button skipButton; // Reference to the Skip Button

    void Start()
    {
        // Ensure the button has an onClick event
        skipButton.onClick.AddListener(SkipVideo);
    }

    void SkipVideo()
    {
        // Stop the video playback
        videoPlayer.Stop();
        // Optionally, you can also hide the video or perform other actions
        gameObject.SetActive(false); // Hide the video object if needed
    }
}
