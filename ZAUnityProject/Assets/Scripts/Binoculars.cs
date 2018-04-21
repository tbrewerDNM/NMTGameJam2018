using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binoculars : MonoBehaviour {

    public AudioClip sound;

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "zucc") {
            Global.hasBinoc = true;
            AudioSource.PlayClipAtPoint(this.sound, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
