using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] double timeMark = 3.0;
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
        Debug.Log("Time is over 3 seconds. " + timeMark);
        if (Time.time > timeMark)
        {
            rb.useGravity = true;
        }
    }
}
