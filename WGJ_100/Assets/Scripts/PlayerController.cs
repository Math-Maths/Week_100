using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] float speed = 3f;
    [SerializeField] float gravityForce = 0.3f;
    [SerializeField] float impulseForce = 1000f;

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
        if (movement.x < 0)
        {
            transform.localScale = new Vector2(characterScale.x * -1, transform.localScale.y);
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector2(characterScale.x, transform.localScale.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Water")
        {
            print("In the water");
            myRigidbody.gravityScale = 0.02f;
        }
        else if(collider.tag == "Sky")
        {
            print("No ar");
            myRigidbody.gravityScale = 1f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Vector2 impulseDir = myRigidbody.velocity.normalized;
            myRigidbody.AddForce(impulseDir * impulseForce * -1, ForceMode2D.Impulse);
        }
    }
}
