using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2 : MonoBehaviour {

    void Update() {
       if (Input.GetKeyDown(KeyCode.Return) && Global.inDoor2) {
            this.GetComponent<AudioSource>().Play();
            Global.ChangeScene(24.25f, 19.62f);
            
            Global.inDoor2 = false;
       }
    }

        void OnTriggerEnter2D(Collider2D collision) {
        Global.inDoor2 = true;
    }
}
