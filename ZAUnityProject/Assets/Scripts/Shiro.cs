using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiro : MonoBehaviour {

    public Animator animator;
    public Lizard zucc;
    public Sword saigo;

    private Sword sword;

    void DestroySword() {
        Destroy(sword.gameObject);
    }

    void Swing() {
        if (this.GetComponent<SpriteRenderer>().flipX) {
            sword = Instantiate(saigo, new Vector3(transform.position.x + 0.718f, -3.31f, -5f), Quaternion.identity);
            sword.parent = this;
            sword.GetComponent<SpriteRenderer>().flipX = true;
        } else {
            sword = Instantiate(saigo, new Vector3(transform.position.x - 1.430f, -3.31f, -5f), Quaternion.identity);
            sword.parent = this;
            sword.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

	// Use this for initialization
	void Start () {
        zucc = FindObjectOfType<Lizard>();
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.rotation = Quaternion.identity;

        if (zucc.transform.position.x >= this.transform.position.x) {
            this.GetComponent<SpriteRenderer>().flipX = true;
            this.transform.position += new Vector3(0.05f, 0, 0);
        } else {
            this.GetComponent<SpriteRenderer>().flipX = false;
            this.transform.position -= new Vector3(0.05f, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "zucc") {
            animator.Play("shiro_swing");
        }
    }
}
