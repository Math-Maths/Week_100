using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float speed = 3f;
    [SerializeField] float gravityForce = 0.3f;
    [SerializeField] float maximumSpeed, breakPower;

    Vector2 characterScale;
    Quaternion defaultRotation;
    Rigidbody2D myRigidbody;

    void Start () {
        characterScale = transform.localScale;
        defaultRotation = transform.rotation;
        myRigidbody = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate ()
    {
        Move();
        SetMaxVelocity();
    }

    private void SetMaxVelocity()
    {
        float speed = Vector3.Magnitude(myRigidbody.velocity); 

        if (speed > maximumSpeed)

        {
            float brakeSpeed = speed - maximumSpeed;  

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
        transform.rotation = defaultRotation;
        Flip(movement);
    }

    void Flip(Vector2 movement)//Flip the object sprite
    {
        if (movement.x < 0.01f)
        {
            transform.localScale = new Vector2(characterScale.x * -1, transform.localScale.y);
        }
        else if (movement.x > 0.01f)
        {
            transform.localScale = new Vector2(characterScale.x, transform.localScale.y);
        }
    }

    
}
