using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    PlayerController playerController;
    PlayerCollisionAndStats playerCollisionAndStats;
    CameraFollow cameraFollow;
    [SerializeField] Oscilatior playerOscilator;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] GameObject MainMenu;
    GameSaver game;

	
    void Awake()
    {
        game = FindObjectOfType<GameSaver>();
        playerController = FindObjectOfType<PlayerController>();
        playerCollisionAndStats = FindObjectOfType<PlayerCollisionAndStats>();
        cameraFollow = FindObjectOfType<CameraFollow>();
        if (game.isReturning)
        {
            StartTheGame();
        }
        else
        {
            cameraFollow.playerAlive = false;
            playerController.enabled = false;
            playerRigidbody.gravityScale = 0;
        }
    }

    public void OnPlayerDeath()
    {
        playerCollisionAndStats.OnPlayerDeath();
        cameraFollow.playerAlive = false;    
    }

    public void StartTheGame()
    {
        MainMenu.SetActive(false);
        playerOscilator.enabled = false;
        cameraFollow.playerAlive = true;
        playerController.enabled = true;
    }
}
