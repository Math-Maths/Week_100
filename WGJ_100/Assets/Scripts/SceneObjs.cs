using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObjs : MonoBehaviour {

    SoundController soundController;

    [SerializeField][Range(0,1)] int MineNum;

    void Start()
    {
        soundController = FindObjectOfType<SoundController>();
    }
    
	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            soundController.PlayExplosionAudio(MineNum);
            Destroy(gameObject);
        }
    }
}
