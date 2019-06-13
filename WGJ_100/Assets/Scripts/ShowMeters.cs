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
	}

	void Update () {
        meterNum = (playerDepth.position.y * -1)/10;
        metersText.text = meterNum.ToString("0") + " m";
	}
}
