using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    void Update() {
       if (Input.GetKeyDown(KeyCode.Return) && Global.inDoor) {
            this.GetComponent<AudioSource>().Play();
            Global.ChangeScene(37.39f, 37.39f);

            Global.inDoor = false;
       }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Global.inDoor = true;
    }
}
