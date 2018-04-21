using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideDoor : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision) {
        Global.inDoor = false;
        Global.inDoor2 = false;
        Global.inDoor3 = false;
        Global.inDoorBlue = false;
        Global.inDoorRed = false;
    }
}
