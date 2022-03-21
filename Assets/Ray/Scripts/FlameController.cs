using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    [SerializeField] float playTime = 3f;
    [SerializeField] float stopTime = 1f;
    [SerializeField] ParticleSystem flame;
    private float temp1, temp2;
    // Start is called before the first frame update
    void Start()
    {
        temp1 = playTime;
        temp2 = stopTime;
    }

    // Update is called once per frame
    void Update()
    {
        // float time = Time.time;
        
        // KeepPlaying();
        if(temp1 > 0)
        {
            temp2 = stopTime;
            KeepPlaying();
            temp1 -= Time.deltaTime;
            // Debug.Log("playTime: " + temp1);
  
        }
        else
        {
            if(temp2 <= 0)
            {
                temp1 = playTime;
            }
            StopPlaying();
            temp2 -= Time.deltaTime;
            // Debug.Log("stopTime: " + temp2);
        }
    }

    void StopPlaying()
    {
        flame.Stop();
        // Invoke("KeepPlaying", stopTime);
        
        // Debug.Log("stop");
    }
    
    void KeepPlaying()
    {
        flame.Play();
        // Invoke("StopPlaying", playTime);
        // Debug.Log("play");
    }
}
