using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryLife : MonoBehaviour {

    private TheZucc zucc;
    public BatteryUI batt1;
    public BatteryUI batt2;
    public BatteryUI batt3;

	// Use this for initialization
	void Start () {
        zucc = FindObjectOfType<TheZucc>();
	}

    // Update is called once per frame
    void Update() {
        float sizex = 0;
        float sizey = 0;

        sizex = 33f - (((float)33f / 1200f) * (3600 - zucc.batteryLife));
        sizey = 33f - (((float)33f / 1200f) * (3600 - zucc.batteryLife));
        batt3.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Clamp(sizex, 0, 33f), Mathf.Clamp(sizey, 0, 33f));

        if (sizex <= 0) {
            sizex = 33f - (((float)33f / 2400f) * (3600 - zucc.batteryLife));
            sizey = 33f - (((float)33f / 2400f) * (3600 - zucc.batteryLife));
            batt2.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Clamp(sizex, 0, 33f), Mathf.Clamp(sizey, 0, 33f));
        }

        if (sizex <= 0) {
            sizex = 33f - (((float)33f / 3600f) * (3600 - zucc.batteryLife));
            sizey = 33f - (((float)33f / 3600f) * (3600 - zucc.batteryLife));
            batt1.GetComponent<RectTransform>().sizeDelta = new Vector2(Mathf.Clamp(sizex, 0, 33f), Mathf.Clamp(sizey, 0, 33f));
        }
    }
}
