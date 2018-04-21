using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    public AudioClip sound;
    public float posx;

    void Update() {
        this.transform.position = new Vector3(posx, this.transform.position.y, this.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "zucc") {
            Global.hasCoin = true;
            AudioSource.PlayClipAtPoint(this.sound, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
