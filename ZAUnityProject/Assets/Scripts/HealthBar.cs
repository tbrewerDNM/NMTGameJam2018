using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Sprite[] sprites;

	// Update is called once per frame
	void Update () {
        this.GetComponent<Image>().sprite = sprites[Global.zuccHealth];
	}
}
