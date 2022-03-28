using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewScript : MonoBehaviour
{
    /*[SerializeField] float x = 0.1F;
    [SerializeField] double y = 0.03D; // SerializeField make you can edit on Unity Editor
    [SerializeField] double z = (int)0.4;*/

    [SerializeField] float moveSpeed = 10f;

    void Start()
    {

    }

    void Update()
    {


        //transform.Translate(x, (float)y, (float)z);

        //Debug.Log(x + " " + y + " " + z); //x = 0.1, y = 3, z = 0
        /*Debug.Log("Vertical " + Input.GetAxis("Vertical"));
        Debug.Log("Time " + Time.deltaTime);*/

        Controller();
    }

    void Controller()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(x, 0, z * 1.0f);
    }
}
