using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 movementVector;
    float movementFactor;
    [SerializeField] [Range(1, 10)] float moveRange = 2f;
    [SerializeField] float period = 2f;
    [SerializeField] bool moveXAxis = false;
    [SerializeField] bool moveYAxis = false;
    [SerializeField] bool moveZAxis = false;
    [SerializeField] bool reverse = false;
    void Start()
    {
        movementVector = transform.position;
        startPosition = transform.position;
    }

    void Update()
    {
        if(period <= Mathf.Epsilon) return; //Epsilon equal smallest float number
        
        const float tau = Mathf.PI * 2; // tau = two PIs, a whole circle, it equal as sine as well

        float cycle = Time.time / period; // 輪(次) = 時間/一次期間
        float rawSineWave = Mathf.Sin(cycle * tau);

        // Debug.LogError("tau: " + tau + " cycle: " + cycle + " rawSineWave: " + rawSineWave);
        movementFactor = (rawSineWave + 1f) * moveRange / 2f; // confused here, "recaculated to go from 0 to 1"
        // Debug.Log(movementFactor + " " + movementVector);
        Vector3 offset = Vector3.forward;

        if(moveXAxis)
        {
            if(reverse)
            {
                offset = Vector3.left * movementFactor;
            }
            else
            {
                offset = Vector3.right * movementFactor;
            }
        }
        if(moveYAxis)
        {
            if(reverse)
            {
                offset = Vector3.down * movementFactor;
            }
            else
            {
                offset = Vector3.up * movementFactor;
            }
        }
        if(moveZAxis)
        {
            if(reverse)
            {
                offset = Vector3.forward * movementFactor;
            }
            else
            {
                offset = Vector3.back * movementFactor;
            }
        }
        Debug.Log(startPosition + " " + offset);
        transform.position = startPosition + offset;
    }
}
