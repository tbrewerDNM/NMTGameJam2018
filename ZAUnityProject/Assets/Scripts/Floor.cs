using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    private TheZucc zucc;

    void Start() {
        zucc = FindObjectOfType<TheZucc>();
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (!(zucc.animator.GetBool("flight")) && zucc.inAir) {
            zucc.animator.SetBool("falling", true);
            zucc.animator.Play("zucc_fall");
            zucc.inAir = false;
        }
    }
}
