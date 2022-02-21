using UnityEngine;
using UnityEngine.SceneManagement;

public class CollsionHandler : MonoBehaviour
{
    int currentScene = 0;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex; // need to transfer scene to index
        Debug.LogError(currentScene);
        // Debug.LogError(SceneManager.sceneCountInBuildSettings);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Game Start");
                break;
            case "Finish":
                NextLevel(currentScene);
                break;
            case "Fuel":
                Debug.Log("collected fuel");
                break;
            default:
                /*Debug.Log("Rocket crashed");*/
                LoadScene(currentScene);
                break;
        }
    }

    void LoadScene(int currentScene)
    {   
        SceneManager.LoadScene(currentScene);
    }
    void NextLevel(int currentScene)
    {
        if (currentScene + 1 == SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(currentScene + 1);
    }
}
