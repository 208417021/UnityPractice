using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    [SerializeField] int playTime = 3;
    [SerializeField] int stopTime = 1;
    [SerializeField] ParticleSystem flame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float time = Time.time;
        Invoke("KeepPlaying", stopTime);
        // KeepPlaying();
    }

    void StopPlaying()
    {
        flame.Stop();
        // Invoke("KeepPlaying", stopTime);
        
        Debug.Log("stop");
    }
    
    void KeepPlaying()
    {
        flame.Play();
        Invoke("StopPlaying", playTime);
        Debug.Log("play");
    }
}
