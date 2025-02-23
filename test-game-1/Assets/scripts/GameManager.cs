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

