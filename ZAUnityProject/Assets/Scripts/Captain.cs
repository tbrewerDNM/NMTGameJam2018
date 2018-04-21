using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captain : Soldier {

    private float posx;

    void Start() {
        this.posx = this.transform.position.x;
    }

    void ChangeDir() {
        this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
    }
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(posx, this.transform.position.y, this.transform.position.z);
        this.transform.rotation = Quaternion.identity;
    }
}
