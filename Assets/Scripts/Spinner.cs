using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float spinSpeed = 1f;
    [SerializeField] bool reverse = false;

    void Update()
    {
        if(reverse)
            transform.Rotate(0, spinSpeed * -1f, 0);
        else
            transform.Rotate(0, spinSpeed, 0);
    }
}
