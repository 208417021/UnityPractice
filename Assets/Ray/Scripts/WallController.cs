using UnityEngine;
using UnityEngine.SceneManagement;

public class WallController : MonoBehaviour
{
    private int currentScene = 0;
    private string eventTag = "";
    // Rigidbody rb;
    GameObject TriggerWall;
    [SerializeField] ParticleSystem explode;
    void Start()
    {
        TriggerWall = GameObject.Find("Trigger Wall");
        TriggerWall.SetActive(false);

        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string eventTag = collision.gameObject.tag;

        // Debug.Log(tag);
        switch(eventTag)
        {
            case "Start":
                GameObject[] start = GameObject.FindGameObjectsWithTag("Start");
                
                foreach(GameObject obj in start)
                {
                    obj.SetActive(false);
                }

                break;
            
            case "Trigger":
                // GameObject.Find("Trigger Wall").SetActive(true);
                TriggerWall.SetActive(true);
                // GetComponent<BoxCollider>().isTrigger = true;
                //Debug.Log("DONE");
                break;
            
            case "Trap":
                collision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
                explode.Play();
                Invoke("DelaySequence", 1);
                //Debug.Log(collision.gameObject.GetComponent<BoxCollider>());
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
