using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    Vector2 startPos;
    [SerializeField] Vector2 parallaxEffect;
    [SerializeField] Camera cam;
	
	void Start () {
        startPos = transform.position;
	}

	void Update () {
        Vector2 dist = new Vector2(cam.transform.position.x * parallaxEffect.x, cam.transform.position.y * parallaxEffect.y);

        transform.position = startPos + dist;
	}
}
