﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionAndStats : MonoBehaviour {

    [SerializeField] float impulseForce = 5f;
    [SerializeField] float waitTime;
    [SerializeField] HealthBar healthBar;
    float health = 1f;
    bool invunerable;
    int i;

    PlayerController playerController;
    Rigidbody2D myRigidbody;
    SpriteRenderer playerSprite;
    PlayerSoundController playerSound;

    IEnumerator EnuSetSprite;

	void Start () {
        invunerable = false;
        EnuSetSprite = SetSpriteRender();
        playerSound = GetComponent<PlayerSoundController>();
        myRigidbody = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        playerSprite = GetComponent<SpriteRenderer>();
	}

    void Update()
    {
        if (playerController.enabled)
        {
            if (transform.position.y > 1.2f)
            {
                myRigidbody.gravityScale = 2.5f;
            }
            else
            {
                myRigidbody.gravityScale = 0.01f;
            }
        }

        if(health <= 0)
        {
            playerSound.DeathFXPlay();         
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!invunerable)
        {
            switch (collision.gameObject.tag)
            {
                case "Wall":
                    CollisionSequence(.1f);
                    break;
                case "Mine":
                    CollisionSequence(.45f);                  
                    break;
            }
        }
        
    }

    private void CollisionSequence(float healthChange)
    {
        invunerable = true;
        playerSound.PlayCrashFX();
        StartCoroutine(EnuSetSprite);
        Vector2 impulseDir = myRigidbody.velocity.normalized;
        myRigidbody.AddForce(impulseDir * impulseForce * -1, ForceMode2D.Impulse);
        health -= healthChange;
        healthBar.SetBarSize(health);
        Invoke("ResetInvunerability", 1f);
    }

    IEnumerator SetSpriteRender()
    {
         i = 0;
        while (i < 17)
        {
            yield return new WaitForSeconds(waitTime);
            if (playerSprite.enabled)
            {
                playerSprite.enabled = false;
            }
            else if (!playerSprite.enabled)
            {
                playerSprite.enabled = true;
            }
            i++;
        }
    }

    void ResetInvunerability()
    {
        invunerable = false;
        StopCoroutine(EnuSetSprite);
        playerSprite.enabled = true;
        i = 0;
    }

    public void OnPlayerDeath()
    {
        myRigidbody.gravityScale = 0.5f;
        invunerable = true;
        playerController.enabled = false;
    }

}
