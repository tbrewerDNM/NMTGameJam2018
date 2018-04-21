using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour {

    public AudioClip sound;
    private TheZucc zucc;
    private float maxy;
    private float miny;
    private float it = 0.01f;

    private void Start() {
        zucc = FindObjectOfType<TheZucc>();
        maxy = this.transform.position.y + 0.1f;
        miny = this.transform.position.y - 0.1f;
    }

    void Update() {

        this.transform.position += new Vector3(0, it, 0);

        if (this.transform.position.y >= maxy || this.transform.position.y <= miny)
            it *= -1;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "zucc") {
            zucc.batteryLife += 1200f;
            AudioSource.PlayClipAtPoint(this.sound, this.transform.position);
            Destroy(this.gameObject);
        }
    }
}
