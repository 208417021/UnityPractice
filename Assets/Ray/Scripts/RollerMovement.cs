using UnityEngine;
using UnityEngine.SceneManagement;

public class RollerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 500f;
    Rigidbody rb;
    Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back * moveSpeed * Time.deltaTime, ForceMode.Acceleration);
        }

        if(transform.position.y < -1)
        {
            GetComponent<RollerMovement>().enabled = false;
            Invoke("DelaySequence", 1);
        }
    }

    void DelaySequence()
    {
        CollsionHandler.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
