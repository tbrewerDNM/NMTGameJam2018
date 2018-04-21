using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatekeeper : MonoBehaviour {

    Animator animator;
    LevelManager lm;

    void Start() {
        this.animator = this.GetComponent<Animator>();
        lm = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "zuccening") {
            animator.Play("gatekeeper_damage");
            Global.gateOpen = true;
            lm.LoadLevel("Mono");
        }
    }
}
