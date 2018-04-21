using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour {

    public int counter = 600;
    public int person;
    public Animator animator;
    public Gun weapon;
    public MessageBoxes[] sprites;
    public int dialogue = 0;
    public MessageBoxes dbox;
    public bool messageOut;
    public Transform trans;
    public AudioClip cashout;

    private int timer = 1;
    private Gun pistol;
    private Vector3 origin;
    private float direction = 0.02f;
    private bool firing = false;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
        origin = this.transform.position;
    }
	
	// Update is called once per frame
	void Update () {

        this.transform.rotation = Quaternion.identity;

        if (person == 0) {
            if (direction > 0 && !firing) {
                this.GetComponent<SpriteRenderer>().flipX = true;
            } else if (!firing) {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }

            if (timer <= 0) {
                firing = true;
                if (direction > 0) {
                    pistol = Instantiate(weapon, this.transform.position += new Vector3(0.611f, -0.063f, 0), Quaternion.identity);
                    pistol.GetComponent<SpriteRenderer>().flipX = true;
                } else {
                    pistol = Instantiate(weapon, this.transform.position += new Vector3(-0.611f, -0.063f, 0), Quaternion.identity);
                    pistol.GetComponent<SpriteRenderer>().flipX = false;
                }
                animator.Play("army_fire");
                pistol.soldier = this;
                timer = counter;
            } else {
                timer--;
            }

            if (this.transform.position.x <= origin.x - 3f) {
                if (!firing)
                    this.GetComponent<SpriteRenderer>().flipX = true;
                direction *= -1f;
            } else if (this.transform.position.x > origin.x + 3f) {
                if (!firing)
                    this.GetComponent<SpriteRenderer>().flipX = false;
                direction *= -1f;
            }

            this.transform.position += new Vector3(direction, 0, 0);
        }
	}

    void NotFiring() {
        this.firing = false;
    }

    void OnCollisionEnter2D(Collision2D collision) {

        if (!messageOut && person != 0)
            if (collision.gameObject.tag == "zucc") {
                messageOut = true;
                switch (person) {
                case 1: //provato

                    if (Global.hasCoin && !Global.hasBear) {
                        dialogue = 0;
                        AudioSource.PlayClipAtPoint(cashout, this.transform.position);
                        Global.hasCoin = false;
                        Global.hasKey = true;
                    } else if (Global.hasCoin && Global.hasBear && !Global.hasRed) {
                        dialogue = 2;
                        AudioSource.PlayClipAtPoint(cashout, this.transform.position);
                        Global.hasCoin = false;
                        Global.hasRed = true;
                    } else if (Global.hasCoin && Global.hasRed && !Global.hasBlue) {
                        dialogue = 3;
                        AudioSource.PlayClipAtPoint(cashout, this.transform.position);
                        Global.hasCoin = false;
                        Global.hasBlue = true;
                    } else if (Global.hasCoin && Global.hasRed && Global.hasBlue) {
                        dialogue = 4;
                    } else {
                        dialogue = 1;
                    }

                    break;
                    case 2: //captain one

                        if (dialogue == 0 && Global.hasBear) {
                            Global.hasCoin = true;
                            dialogue++;
                        }

                        break;
                    case 3: //captain two

                        if (dialogue == 0 && Global.hasBinoc) {
                            Global.hasCoin = true;
                            dialogue++;
                        }

                        break;

                }

                if (sprites != null) {
                    dbox = Instantiate(sprites[dialogue], transform.position + new Vector3(2f, 1.34f, 0f), Quaternion.identity);
                }

                switch (person) {
                    case 1: //provato

                        if (dialogue == 3)
                            dialogue++;
  
                        break;
                    case 2: //captain one

                        if (dialogue == 1)
                            dialogue++;

                        break;
                    case 3: //captain two

                        if (dialogue == 1)
                            dialogue++;

                        break;

                }
            }
    }
}
