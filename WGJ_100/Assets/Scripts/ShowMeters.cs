using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMeters : MonoBehaviour {

    [SerializeField] Transform playerDepth;
    float meterNum;
    Text metersText;

	void Start () {
        metersText = GetComponent<Text>();
        metersText.text = "0 m";
	}

	void Update () {
        meterNum = (playerDepth.position.y * -1)/1.8f;
        if(meterNum >=0 && meterNum <= 100)
        metersText.text = meterNum.ToString("0") + " m";
	}
}
