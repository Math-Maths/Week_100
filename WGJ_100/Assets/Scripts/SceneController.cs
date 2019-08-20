using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    PlayerController playerController;
    PlayerSoundController playerSound;
    PlayerCollisionAndStats playerCollisionAndStats;
    CameraFollow cameraFollow;
    SoundController soundController;
    GameSaver game;
    AmbientationSoundFX ambientationSound;

    //---------------------------------------------------------------------------

    [SerializeField] BoxCollider2D waterCollider;
    [SerializeField] Oscilatior playerOscilator;
    [SerializeField] Rigidbody2D playerRigidbody;
    [SerializeField] GameObject MainMenu;
    [SerializeField] AudioSource Theme;
    [SerializeField] SpriteRenderer playerSprite;
	
    void Awake()
    {
        game = FindObjectOfType<GameSaver>();
        ambientationSound = FindObjectOfType<AmbientationSoundFX>();
        playerSprite.enabled = false;
        playerSound = FindObjectOfType<PlayerSoundController>();
        playerController = FindObjectOfType<PlayerController>();
        playerCollisionAndStats = FindObjectOfType<PlayerCollisionAndStats>();
        cameraFollow = FindObjectOfType<CameraFollow>();
        soundController = GetComponent<SoundController>();
        waterCollider.enabled = false;
        ambientationSound.enabled = false;
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
        Theme.Stop();
        soundController.PlayFX();
        playerSprite.enabled = true;
        MainMenu.SetActive(false);
        playerOscilator.enabled = false;
        cameraFollow.playerAlive = true;
        playerController.enabled = true;
        playerSound.StartEngine();
        waterCollider.enabled = true;
        ambientationSound.enabled = true;
    }
}
