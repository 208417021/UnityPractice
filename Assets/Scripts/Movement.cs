using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 100f;
    [SerializeField] float rotationSpeed = 50f;
    // [SerializeField] float audioVolume = 1f;
    // Start is called before the first frame update
    Rigidbody rb;
    AudioSource audioSource;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        
        // audioSource.volume = audioVolume;
    }

    void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //transform.Translate(0, moveSpeed * Time.deltaTime, 0);
            rb.AddRelativeForce(Vector3.up * moveSpeed * Time.deltaTime); //move to the direction, Vector3.up = (0,1,0)
            //remember the mass of game object to use AddRelativeForce()
            //Debug.Log("SPACE");
            // if(!audioSource.isPlaying)
            //     audioSource.Play();
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //transform.Rotate(-1, 0, 0);
            Rotation(rotationSpeed);
            //Debug.Log(GetComponent<Transform>().rotation.x);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Rotation(-rotationSpeed);
            //Debug.Log(GetComponent<Transform>().rotation.x);
        }
    }

    private void Rotation(float speed)
    {
        rb.freezeRotation = true; //freezing rotation if hit obstacle
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
