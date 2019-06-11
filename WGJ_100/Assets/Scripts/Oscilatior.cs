using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscilatior : MonoBehaviour {

    [SerializeField] Vector3 movementeVector;

    float movementeFactor;
    [SerializeField] float period = 2f;
    
    Vector3 startingPos;
	
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if(Mathf.Abs(period) <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        
        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau);

        movementeFactor = rawSinWave / 2f + .5f;
        Vector3 offSet = movementeVector * movementeFactor;
        transform.position = startingPos + offSet;
	}
}
