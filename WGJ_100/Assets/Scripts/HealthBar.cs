﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    Transform bar;
    SceneController sceneManager;
    ButtonsFunctions buttonsFunctions;

	void Start () {
        bar = transform.Find("Bar");
        sceneManager = FindObjectOfType<SceneController>();
        buttonsFunctions = FindObjectOfType<ButtonsFunctions>();
	}
	
	public void SetBarSize(float barNewSize)
    {
        if (barNewSize > 0)
        {
            bar.localScale = new Vector3(barNewSize, 1f, 1f);
        }
        else if(barNewSize <= 0)
        {
            bar.localScale = new Vector3(0, 1f, 1f);
            sceneManager.OnPlayerDeath();
            buttonsFunctions.InvokeReloadScene();
        }
    }
}
