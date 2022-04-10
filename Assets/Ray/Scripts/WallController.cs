using UnityEngine;
using UnityEngine.SceneManagement;

public class WallController : MonoBehaviour
{
    private int currentScene = 0;
    private string eventTag = "";
    // Rigidbody rb;
    private GameObject[] TriggerWall;
    [SerializeField] ParticleSystem explode;
    void Start()
    {
        TriggerWall = GameObject.FindGameObjectsWithTag("TriggerWall");

        foreach (GameObject obj in TriggerWall)
            obj.SetActive(false);

        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        string eventTag = collision.gameObject.tag;

        // Debug.Log(tag);
        switch (eventTag)
        {
            case "Start":
                GameObject[] start = GameObject.FindGameObjectsWithTag("Start");

                foreach (GameObject obj in start)
                {
                    obj.SetActive(false);
                }

                break;

            case "TriggerOn":
                foreach (GameObject obj in TriggerWall)
                    obj.SetActive(true);
                //Debug.Log("DONE");
                break;

            case "TriggerOff":
                foreach (GameObject obj in TriggerWall)
                    obj.SetActive(false);
                //Debug.Log("DONE");
                break;

            case "Trap":
                collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                explode.Play();
                Invoke("DelaySequence", 1);
                //Debug.Log(collision.gameObject.GetComponent<BoxCollider>());
                break;
            case "EndTrigger":
                GameObject[] end = GameObject.FindGameObjectsWithTag("EndTrigger");
                foreach (GameObject obj in end)
                    obj.SetActive(false);
                break;
            case "Finish":
                Debug.Log("Game Finish");
                break;
            default:
                break;
        }
    }

    public void DelaySequence()
    {
        if (eventTag.Equals("Finish"))
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
