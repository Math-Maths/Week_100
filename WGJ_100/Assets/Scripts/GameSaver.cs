using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSaver : MonoBehaviour {

    public bool isReturning = false;

    void Awake()
    {
        int gameSavers = FindObjectsOfType<GameSaver>().Length;
        if(gameSavers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
	
}
