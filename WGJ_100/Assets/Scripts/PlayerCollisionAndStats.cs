using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionAndStats : MonoBehaviour {

    [SerializeField] float impulseForce = 5f;
    [SerializeField] HealthBar healthBar;
    float health = 1f;

    PlayerController playerController;
    Rigidbody2D myRigidbody;

	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Water")
        {
            print("In the water");
            myRigidbody.gravityScale = 0.02f;
        }
        else if (collider.tag == "Sky")
        {
            print("No ar");
            myRigidbody.gravityScale = 1f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag){
            case "Wall":
                CollisionSequence(.1f);
                break;
            case "Mine":
                CollisionSequence(.45f);
                break;
        }
        
    }

    private void CollisionSequence(float healthChange)
    {
        Vector2 impulseDir = myRigidbody.velocity.normalized;
        myRigidbody.AddForce(impulseDir * impulseForce * -1, ForceMode2D.Impulse);
        health -= healthChange;
        healthBar.SetBarSize(health);
    }

}
