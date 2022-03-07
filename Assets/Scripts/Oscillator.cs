using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(1, 10)] float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        movementVector = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) return; //Epsilon equal smallest float number

        const float tau = Mathf.PI * 2; // tau = two PIs, a whole circle, it equal as sine as well

        float cycle = Time.time / period; // 輪(次) = 時間/一次期間
        float rawSineWave = Mathf.Sin(cycle * tau);

        // Debug.LogError("tau: " + tau + " cycle: " + cycle + " rawSineWave: " + rawSineWave);
        movementFactor = (rawSineWave + 1f) ; // confused here, "recaculated to go from 0 to 1"
        Vector3 offset = movementVector * movementFactor;

        transform.position = startPosition + offset;
    }
}
