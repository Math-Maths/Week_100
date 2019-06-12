using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    PlayerController playerController;
    PlayerCollisionAndStats playerCollisionAndStats;
    CameraFollow cameraFollow;
    [SerializeField] Oscilatior playerOscilator;
	
    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        playerCollisionAndStats = FindObjectOfType<PlayerCollisionAndStats>();
        cameraFollow = FindObjectOfType<CameraFollow>();
        cameraFollow.playerAlive = false;
        playerController.enabled = false;
    }

	void Start () {
        
	}
	
	
	void Update () {
        
	}

    public void OnPlayerDeath()
    {
        playerCollisionAndStats.OnPlayerDeath();
        cameraFollow.playerAlive = false;
    }

    public void StartTheGame()
    {
        playerOscilator.enabled = false;
        cameraFollow.playerAlive = true;
        playerController.enabled = true;
    }
}
