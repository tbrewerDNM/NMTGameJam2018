using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3 : MonoBehaviour {

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && Global.inDoor3 && Global.hasKey) {
            this.GetComponent<AudioSource>().Play();
            Global.ChangeScene(-21.27501f, -26.3f, -1.55f);

            Global.inDoor3 = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Global.inDoor3 = true;
    }
}
