using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    AudioSource source;
    [SerializeField] AudioClip playFX;
    [SerializeField] AudioClip[] mineExplosionFXs;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlayExplosionAudio(int mineIndex)
    {
        source.PlayOneShot(mineExplosionFXs[mineIndex]);
    }	

    public void PlayFX()
    {
        source = GetComponent<AudioSource>();
        source.volume = .4f;
        source.PlayOneShot(playFX);
    }
}
