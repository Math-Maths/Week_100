using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    Transform bar;

	void Start () {
        bar = transform.Find("Bar");
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
        }
    }
}
