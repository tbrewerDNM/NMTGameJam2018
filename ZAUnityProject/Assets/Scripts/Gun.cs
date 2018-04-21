using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Soldier soldier;
    public Animator animator;
    public Bullet bullet;
    public AudioClip sound;

    private Bullet proj;

    void Suicide() {
        Destroy(this.gameObject);
    }

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
        AudioSource.PlayClipAtPoint(this.sound, this.transform.position);
        if (this.GetComponent<SpriteRenderer>().flipX) {
            proj = Instantiate(bullet, this.transform.position + new Vector3(2.54f, 0.376f, -1f), Quaternion.identity);
            proj.direction = 1f;
        } else {
            proj = Instantiate(bullet, this.transform.position + new Vector3(-2.54f, 0.376f, -1f), Quaternion.identity);
            proj.direction = -1f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<SpriteRenderer>().flipX) {
            this.transform.position = soldier.transform.position + new Vector3(0.611f, -0.063f, 1);
        } else {
            this.transform.position = soldier.transform.position + new Vector3(-0.611f, -0.063f, 1);
        }
	}
}
