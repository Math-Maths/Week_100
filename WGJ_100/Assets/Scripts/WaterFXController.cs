using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFXController : MonoBehaviour {

    [SerializeField] AudioClip[] waterFXs;

    AudioSource waterFXPlayer;
	
	void Start () {
        waterFXPlayer = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter2D(Collider2D collider)
    {
        if (!waterFXPlayer.isPlaying)
        {
            waterFXPlayer.PlayOneShot(waterFXs[Random.Range(0, 2)]);
        }
    }
}
