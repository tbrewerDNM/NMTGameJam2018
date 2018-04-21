using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public AudioClip sound;
    public int type;

    void OnTriggerEnter2D(Collider2D collider) {

        if (type == 0)
            Global.hasKey = true;
        else if (type == 1)
            Global.hasRed = true;
        else if (type == 2)
            Global.hasBlue = true;

        AudioSource.PlayClipAtPoint(this.sound, this.transform.position);
        Destroy(this.gameObject);
    }
}
