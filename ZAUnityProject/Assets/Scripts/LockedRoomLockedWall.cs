using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedRoomLockedWall : Boundary {

    void OnCollisionEnter2D(Collision2D collision) {
        
        if (Global.hasKey) {
            Global.ChangeScene(zuccDestx, cameraDestx);
            Global.hasKey = false;
        } else {
            collision.transform.position = collision.transform.position;
        }
    }
}
