using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoModeManager : MonoBehaviour
{
    public GameObject player;
    public float demoDuration = 30f;
    public string returnToScene = "game-lobby";

    private bool isDemoMode = false;
    private float timer = 0f;

    private AutoPlay autoPlay;
    private PlayerMovement playerMovement;

    void Start()
    {
        // Only run if this session is a demo session
        if (!DemoState.isDemoMode)
        {
            Debug.Log("🚫 Not in demo mode — skipping auto control.");
            return;
        }

        isDemoMode = true;
        Debug.Log("✅ DEMO MODE ACTIVE");

        autoPlay = player.GetComponent<AutoPlay>();
        playerMovement = player.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            playerMovement.enabled = false;
            Debug.Log("🛑 Disabled PlayerMovement");
        }

        if (autoPlay != null)
        {
            autoPlay.enabled = true;
            Debug.Log("✅ Enabled AutoPlay");
        }
    }

    void Update()
    {
        if (!isDemoMode) return;

        timer += Time.deltaTime;

        if (Input.anyKeyDown)
        {
            Debug.Log("🛑 Key pressed — stopping demo mode");
            StopDemoMode();
        }
        else if (timer >= demoDuration)
        {
            Debug.Log("⏱️ Demo time over — loading " + returnToScene);
            SceneManager.LoadScene(returnToScene);
        }
    }

    void StopDemoMode()
    {
        isDemoMode = false;
        DemoState.isDemoMode = false; // Reset the flag

        if (autoPlay != null)
        {
            autoPlay.enabled = false;
            Debug.Log("🔻 Disabled AutoPlay");
        }

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
            Debug.Log("✅ Re-enabled PlayerMovement");
        }
    }
}
