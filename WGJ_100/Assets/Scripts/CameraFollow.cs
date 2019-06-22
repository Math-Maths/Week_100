using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 10f;
    [SerializeField] Vector3 offSet;

    public bool playerAlive;


    void FixedUpdate()
    {
        if (playerAlive)
        {
            smoothSpeed = 5;
            Vector3 desiredPosition = target.position + offSet;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, smoothedPosition.y, transform.position.z);
        }
    }

}
