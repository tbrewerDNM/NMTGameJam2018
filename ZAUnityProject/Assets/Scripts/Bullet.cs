using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float direction;

	// Update is called once per frame
	void Update () {
        float x = this.transform.position.x;
        x += 0.05f * direction;
        this.transform.position = new Vector3(x, this.transform.position.y, this.transform.position.z);
	}
}
