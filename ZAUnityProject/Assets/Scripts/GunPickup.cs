using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour {

    public AudioClip sound;

    void OnTriggerEnter2D(Collider2D collider) {
        Global.hasGun = true;
        //AudioSource.PlayClipAtPoint(this.sound, this.transform.position);
        Destroy(this.gameObject);
    }
}
