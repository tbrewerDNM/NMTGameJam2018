using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour {

    public AudioClip sound;

    void OnTriggerEnter2D(Collider2D collider) {
        Global.hasBear = true;
        AudioSource.PlayClipAtPoint(this.sound, this.transform.position);
        Destroy(this.gameObject);
    }
}
