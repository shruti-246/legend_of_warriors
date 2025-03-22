using UnityEngine;
using UnityEngine.Video; // Make sure to include this namespace
using UnityEngine.UI; // Include this for Button
using UnityEngine.SceneManagement; // Include this for SceneManager

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer
    public Button skipButton; // Reference to the Skip Button

    void Start()
    {
        // Ensure the button has an onClick event
        skipButton.onClick.AddListener(SkipVideo);
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    void SkipVideo()
    {
        // // Stop the video playback
        // videoPlayer.Stop();
        // // Optionally, you can also hide the video or perform other actions
        // gameObject.SetActive(false); // Hide the video object if needed
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
