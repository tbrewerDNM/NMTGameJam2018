using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ceiling : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision) {
        collision.transform.position = collision.transform.position;
    }
}
