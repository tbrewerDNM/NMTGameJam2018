using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public Shiro parent;
    private Lizard zucc;

    // Use this for initialization
    void Start () {
        zucc = FindObjectOfType<Lizard>();
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.rotation = Quaternion.identity;

        if (parent.GetComponent<SpriteRenderer>().flipX) {
            this.transform.position = new Vector3(transform.position.x + 0.718f, -3.31f, -5f);
            this.GetComponent<SpriteRenderer>().flipX = true;
        } else {
            this.transform.position = new Vector3(transform.position.x - 1.43f, -3.31f, -5f);
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "zucc") {
            zucc.animator.Play("liz_hurt");
            Global.zuccHealth--;

            if (Global.zuccHealth <= 0)
                zucc.lm.LoadLevel("Lose");
        }
    }
}
