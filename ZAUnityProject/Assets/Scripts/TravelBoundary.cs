using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelBoundary : Boundary {

    public float zuccy;

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.GetType().Name == "PolygonCollider2D")
            Destroy(collision.gameObject);
        else if (collision.gameObject.tag == "zucc") {
            if (zuccy == 0)
                Global.ChangeScene(zuccDestx, cameraDestx);
            else
                Global.ChangeScene(zuccDestx, cameraDestx, zuccy);
        }
    }
}
