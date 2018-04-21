using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheZucc : MonoBehaviour {

    public Animator animator;
    public Fire fire;
    public Gun2 pistol;
    public Bullet bullet;
    private Fire jet;
    public float rate = 0.05f;
    public float maxFuel = 2f;
    public float batteryLife = 3600f;
    private float increment;
    private FuelBar fb;
    private float zuccy;
    public bool inAir = false;
    public LevelManager lm;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
        fb = FindObjectOfType<FuelBar>();
        zuccy = this.transform.position.y;
        lm = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {

        batteryLife -= 1.0f;

        if (batteryLife <= 0 && !(Global.gateOpen))
            lm.LoadLevel("Lose");

        if (zuccy != this.transform.position.y) {
            inAir = true;
        }

        if (!inAir)
            zuccy = this.transform.position.y;

        if (Global.hasGun && Input.GetKeyDown(KeyCode.Return)) {
            if (this.GetComponent<SpriteRenderer>().flipX) {
                pistol = Instantiate(pistol, this.transform.position += new Vector3(0.611f, -0.063f, 0), Quaternion.identity);
                pistol.bullet = bullet;
                pistol.GetComponent<SpriteRenderer>().flipX = true;
            } else {
                pistol = Instantiate(pistol, this.transform.position += new Vector3(-0.611f, -0.063f, 0), Quaternion.identity);
                pistol.bullet = bullet;
                pistol.GetComponent<SpriteRenderer>().flipX = false;
            }
            animator.Play("zucc_fire");
            Global.hasGun = false;
        }

        this.transform.rotation = Quaternion.identity;
        increment = (float) 174.14f / maxFuel;

        if (!(Input.GetKey(KeyCode.Space)) && fb.GetComponent<RectTransform>().sizeDelta.x <= 174.14) {
            fb.GetComponent<RectTransform>().sizeDelta += new Vector2(increment, 0f);
            fb.GetComponent<RectTransform>().anchoredPosition += new Vector2((float)increment / 2, 0f);
        }

        if (!(Input.GetKey(KeyCode.Space)) || fb.GetComponent<RectTransform>().sizeDelta.x <= 0) {
            if (jet != null)
                Destroy(jet.gameObject);
            animator.SetBool("flight", false);
            this.GetComponent<Rigidbody2D>().gravityScale = 1;
        } else if (jet != null && fb.GetComponent<RectTransform>().sizeDelta.x >= 0) {
            fb.GetComponent<RectTransform>().sizeDelta -= new Vector2(increment, 0f);
            fb.GetComponent<RectTransform>().anchoredPosition -= new Vector2((float)increment / 2, 0f);
            this.transform.position += new Vector3(0f, rate, 0f);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            this.transform.position += new Vector3(0.1f, 0f, 0f);
            this.transform.GetComponent<SpriteRenderer>().flipX = true;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.position += new Vector3(-0.1f, 0f, 0f);
            this.transform.GetComponent<SpriteRenderer>().flipX = false;
        } else if (Input.GetKey(KeyCode.Space) && jet == null) {
            animator.SetBool("falling", false);
            animator.SetBool("flight", true);
            animator.Play("zucc_fly");
            jet = Instantiate(fire, this.transform.position - new Vector3(0f, 1f, 0), Quaternion.identity);
            jet.GetComponent<AudioSource>().Play();
            jet.attached = this;
            this.transform.position += new Vector3(0f, 0.1f, 0f);
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "bullet") {
            Global.zuccHealth -= 1;
            animator.Play("zucc_damage");
            Destroy(collision.gameObject);
        }
    }
}
