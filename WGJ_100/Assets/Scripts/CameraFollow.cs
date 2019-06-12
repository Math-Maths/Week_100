using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 10f;

    [SerializeField] Vector3 offSet;
	
	void FixedUpdate () {

        Vector3 desiredPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
	}
}
