using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

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
        else if (Global.gateOpen && collision.gameObject.tag == "zucc")
            Global.ChangeScene(-108.316f, -102.78f, -3.11f);
        else
            collision.transform.position = collision.transform.position;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        Destroy(collision.gameObject);
    }

    void Update() {
        if (Global.gateOpen) {
            this.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
