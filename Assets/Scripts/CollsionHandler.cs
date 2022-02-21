using UnityEngine;
using UnityEngine.SceneManagement;

public class CollsionHandler : MonoBehaviour
{
    private int currentScene = 0;
    [SerializeField] float delayTime = 1f;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex; // need to transfer scene to index
        GetComponent<Movement>().enabled = true;
        // Debug.LogError(currentScene);
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
                GetComponent<Movement>().enabled = false;
                Invoke("DelaySequence", delayTime);
                // LoadScene(currentScene);
                break;
        }
    }

    void DelaySequence()
    {
        LoadScene(currentScene);
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
