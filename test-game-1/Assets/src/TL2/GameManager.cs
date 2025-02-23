using UnityEngine;
using UnityEngine.SceneManagement;


public class gameManager : MonoBehaviour {

    public static gameManager Instance; //singeleton instance

    private void Awake()
    {
        //ensure only one instance of the game is awake
        if(Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);      //gameobject refers to this empty gameobject here. 
        }
        else{
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "logo-scene"){
            StartCoroutine(LoadNextSceneAfterDelay(5f));
        }
    }

    private void Update()
    {
        // if the user presses the escape key, quit the game
        if(Input.GetKeyDown(KeyCode.Escape)){
            LoadScene("game-lobby");
        }
    }

    private System.Collections.IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene("video-scene");
    }

    // method to load scene
    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    // Method to quit the game
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }


}

