using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] [Range(0, 1000)]float dropSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log((double)Time.time);
        //timeMark = Time.time;
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Drop");
        // Debug.LogError(GameObject.Find("Player").transform.position.x);
        if (GameObject.Find("Player").transform.position.x > -15f)
        {
            rb.useGravity = true;
            rb.AddRelativeForce(Vector3.down * dropSpeed * Time.deltaTime);
        }
    }
}
