using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBarrier : Boundary {

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.GetType().Name == "PolygonCollider2D")
            Destroy(collision.gameObject);
        else if (collision.gameObject.tag == "zucc") {
            if (Global.gateOpen)
                Global.ChangeScene(zuccDestx, cameraDestx);
            else
                collision.transform.position = collision.transform.position;
        }
    }
}
