using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreer : MonoBehaviour
{
    int hits = 0;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Obstacle")
        {
            hits++;
            Debug.Log("hits: " + hits);
        }
        
    }
}
