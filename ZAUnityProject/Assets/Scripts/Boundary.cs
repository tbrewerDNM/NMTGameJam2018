using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

    protected TheZucc zucc;
    protected Cam cam;
    public float zuccDestx;
    public float cameraDestx;

    void Start() {
        zucc = FindObjectOfType<TheZucc>();
        cam = FindObjectOfType<Cam>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.GetType().Name == "PolygonCollider2D")
            Destroy(collision.gameObject);
        else
            collision.transform.position = collision.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Destroy(collision.gameObject);
    }
}
