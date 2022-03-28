using UnityEngine;

public class WallController : MonoBehaviour
{
    // Rigidbody rb;
    GameObject TriggerWall;
    void Start()
    {
        TriggerWall = GameObject.Find("Trigger Wall");
        TriggerWall.SetActive(false);
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string tag = collision.gameObject.tag;

        // Debug.Log(tag);
        switch(tag)
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
                Debug.Log("DONE");
                break;
            
            case "Trap":
                GameObject[] traps = GameObject.FindGameObjectsWithTag("Trap");

                foreach(GameObject trap in traps)
                {
                    trap.GetComponent<BoxCollider>().isTrigger = true;
                    // Debug.Log("TEST: " + trap.GetType());
                }
                break;
            default:
                break;
        }
    }
}
