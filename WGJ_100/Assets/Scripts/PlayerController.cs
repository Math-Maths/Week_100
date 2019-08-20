using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float speed = 3f;
    [SerializeField] float maximumSpeed, breakPower;

    float YRotation;
    Rigidbody2D myRigidbody;

    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        YRotation = 0;
    }

	void FixedUpdate ()
    {
        Move();
        SetMaxVelocity();
    }

    private void SetMaxVelocity()
    {
        float currentSpeed = Vector3.Magnitude(myRigidbody.velocity); 

        if (currentSpeed > maximumSpeed)

        {
            float brakeSpeed = currentSpeed - maximumSpeed;  

            Vector3 normalisedVelocity = myRigidbody.velocity.normalized;
            Vector3 brakeVelocity = normalisedVelocity * brakeSpeed * breakPower;  

            myRigidbody.AddForce(-brakeVelocity);  
        }
    }

    private void Move()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 movement = dir * speed * Time.deltaTime;
        myRigidbody.AddForce(movement);
        Flip(movement);

    }

    void Flip(Vector2 movement)//Flip the object sprite
    {
        if (movement.x < 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, Input.GetAxis("Vertical") * 30));
            YRotation = 180;
        }
        else if (movement.x > 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Input.GetAxis("Vertical") * 30));
            YRotation = 0;
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, YRotation, Input.GetAxis("Vertical") * 30));
        }
    }
    
}
