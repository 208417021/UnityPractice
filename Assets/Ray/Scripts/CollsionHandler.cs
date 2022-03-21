using UnityEngine;
using UnityEngine.SceneManagement;

public class CollsionHandler : MonoBehaviour
{
    private int currentScene = 0;
    private string eventTag = "";
    private bool isRocket, isRoller;
    [SerializeField] float delayTime = 1f;
    [SerializeField] ParticleSystem finish;
    [SerializeField] ParticleSystem crash;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex; // need to transfer scene to index
        Debug.Log("TEST: " + GetComponent<RocketMovement>() == null);
        isRocket = !GetComponent<RocketMovement>().Equals(null);
        isRoller = !GetComponent<RollerMovement>().Equals(null);

        if(isRocket)
        {
            GetComponent<RocketMovement>().enabled = true;
        }
        if(isRoller)
        {
            GetComponent<RollerMovement>().enabled = true;
        }
        // Debug.LogError(currentScene);
        // Debug.LogError(SceneManager.sceneCountInBuildSettings);
    }

    private void OnCollisionEnter(Collision collision)
    {
        eventTag = collision.gameObject.tag;
        // Debug.Log(eventTag);
        // Debug.Log(GetComponent<RocketMovement>());
        // Debug.Log(GetComponent<RollerMovement>());
        switch (eventTag)
        {
            case "Friendly":
                Debug.Log("Game Start");
                break;
            case "Finish":
                //NextLevel(currentScene);
                if(isRocket)
                {
                    GetComponent<RocketMovement>().enabled = false;
                }
                if(isRoller)
                {
                    GetComponent<RollerMovement>().enabled = false;
                }
                finish.Play();
                Invoke("DelaySequence", delayTime);
                break;
            case "Fuel":
                Debug.Log("collected fuel");
                break;
            default:
                /*Debug.Log("Rocket crashed");*/
                if(isRocket)
                {
                    GetComponent<RocketMovement>().enabled = false;
                }
                if(isRoller)
                {
                    GetComponent<RollerMovement>().enabled = false;
                }
                crash.Play();
                Invoke("DelaySequence", delayTime);
                // LoadScene(currentScene);
                break;
        }
    }

    public void DelaySequence()
    {
        if(eventTag.Equals("Finish"))
            NextLevel(currentScene);
        else
            LoadScene(currentScene);
    }
    public static void LoadScene(int currentScene)
    {   
        SceneManager.LoadScene(currentScene);
    }
    public static void NextLevel(int currentScene)
    {
        if (currentScene + 1 == SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(currentScene + 1);
    }
}