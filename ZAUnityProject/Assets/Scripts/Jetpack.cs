using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jetpack : MonoBehaviour {

    public AudioClip sound;
    private TheZucc zucc;

    void Start() {
        zucc = FindObjectOfType<TheZucc>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        zucc.rate = 0.1f;
        zucc.maxFuel = 200f;
        AudioSource.PlayClipAtPoint(this.sound, this.transform.position);
        Destroy(this.gameObject);
    }
}

