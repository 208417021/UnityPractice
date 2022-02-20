using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) { //private means only can use on this class, "other" = the collision has been fired with
        // Debug.Log(other + " bumped");

        
        if (other.gameObject.tag.Equals("Player")) // hit by player
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Obstacle";
        }
        
        // GetComponent<MeshRenderer>().material.color = Color.reset(C)
        //Debug.Log(GameObject.Find("Player").name);
    }
}
