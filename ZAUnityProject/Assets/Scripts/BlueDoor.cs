using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour {

    void Update() {
       if (Input.GetKeyDown(KeyCode.Return) && Global.inDoorBlue && Global.hasBlue) {
            this.GetComponent<AudioSource>().Play();
            Global.ChangeScene(-62.27623f, -67.71f, -3.038642f);
            
            Global.inDoorBlue = false;
       }
    }

        void OnTriggerEnter2D(Collider2D collision) {
        Global.inDoorBlue = true;
    }
}
