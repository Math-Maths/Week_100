using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundController : MonoBehaviour {

    [SerializeField] AudioClip crashAudio, deathFX;

    AudioSource playerAudio;
    [SerializeField] AudioSource playerEngine, motorFX;

    bool alive;

	void Start () {
        alive = true;
        playerAudio = GetComponent<AudioSource>();
	}
	
    void Update()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0 || Mathf.Abs(Input.GetAxis("Vertical")) > 0)
        {
            if (!motorFX.isPlaying)
            {
                motorFX.Play();
            }
        }
        else
        {
            motorFX.Stop();
        }
    }

	public void PlayCrashFX()
    {
        playerAudio.PlayOneShot(crashAudio);
    }

    public void DeathFXPlay()
    {
        playerAudio.volume = .5f;
        if (alive)
        {
            playerAudio.PlayOneShot(deathFX);
        }
        alive = false;
    }

    public void StartEngine()
    {
        playerEngine.Play();
    }
}
