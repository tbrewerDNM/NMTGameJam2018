using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDoor : MonoBehaviour {

    void Update() {
       if (Input.GetKeyDown(KeyCode.Return) && Global.inDoorRed && Global.hasRed) {
            this.GetComponent<AudioSource>().Play();
            Global.ChangeScene(-42.42f, -47.92f, -3.24f);
            
            Global.inDoorRed = false;
       }
    }

        void OnTriggerEnter2D(Collider2D collision) {
        Global.inDoorRed = true;
    }
}
