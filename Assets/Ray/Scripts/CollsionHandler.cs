using UnityEngine;
using UnityEngine.SceneManagement;

public class CollsionHandler : MonoBehaviour
{
    private int currentScene = 0;
    private bool isRocket, isRoller, isGoal;
    [SerializeField] float delayTime = 1f;
    [SerializeField] bool isCheating = false;
    [SerializeField] ParticleSystem finish;
    [SerializeField] ParticleSystem crash;
    [SerializeField] AudioSource crashSound;
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex; // need to transfer scene to index
        // Debug.Log("TEST: " + GetComponent<RocketMovement>() == null);
        isRocket = GetComponent<RocketMovement>() != null;
        isRoller = GetComponent<RollerMovement>() != null;
        isGoal = false;

        if(isRocket)
        {
            GetComponent<RocketMovement>().enabled = true;
            crashSound = GetComponent<Audio>().GetComponent<AudioSource>();
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
        string eventTag = collision.gameObject.tag;

        switch (eventTag)
        {
            case "Start": 
            case"Friendly":
                break;
            case "Finish":
                isGoal = true;
                if (isRocket)
                {
                    GetComponent<RocketMovement>().enabled = false;
                }
                if (isRoller)
                {
                    GetComponent<RollerMovement>().enabled = false;
                }
                finish.Play();
                Invoke("DelaySequence", delayTime);
                GetComponent<CollsionHandler>().enabled = false;
                break;
            default:
                if(isCheating || isGoal) break;
                if(isRocket)
                {
                    GetComponent<RocketMovement>().enabled = false;
                }
                if(isRoller)
                {
                    GetComponent<RollerMovement>().enabled = false;
                }
                crash.Play();
                crashSound.Play();
                Invoke("DelaySequence", delayTime);

                break;
        }
    }

    public void DelaySequence()
    {
        if(isGoal)
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
