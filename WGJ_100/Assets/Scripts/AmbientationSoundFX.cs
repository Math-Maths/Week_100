using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientationSoundFX : MonoBehaviour {

    AudioSource ambientationSource;
    ShowMeters meters;

    [SerializeField] AudioClip tropical, underwater;
	
	void Start () {
        meters = FindObjectOfType<ShowMeters>();
        ambientationSource = GetComponent<AudioSource>();
	}
	
	void Update () {
    
		if(meters.meterNum <= 1.3f)
        {
            ambientationSource.clip = tropical;
            if (!ambientationSource.isPlaying)
            {
                ambientationSource.Play();
            }
        }
        else
        {
            ambientationSource.clip = underwater;
            if (!ambientationSource.isPlaying)
            {
                ambientationSource.Play();
            }
        }
	}
}
