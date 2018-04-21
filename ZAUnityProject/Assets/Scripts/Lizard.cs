using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour {

    public Animator animator;
    public BossHealth bh;
    public LevelManager lm;
    public Shiro shiro;
    public AudioClip sound;

    public bool attacking = false;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
        lm = FindObjectOfType<LevelManager>();
        bh = FindObjectOfType<BossHealth>();
        shiro = FindObjectOfType<Shiro>();
	}

    void StopAttack() {
        this.attacking = false;
    }
	
	// Update is called once per frame
	void Update () {

        this.transform.rotation = Quaternion.identity;

        if (Input.GetKeyDown(KeyCode.Space)) {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500f));
        } else if (Input.GetKey(KeyCode.RightArrow) && !attacking) {
            animator.Play("liz_walk");
            this.GetComponent<SpriteRenderer>().flipX = true;
            this.transform.position += new Vector3(0.1f, 0, 0);
        } else if (Input.GetKey(KeyCode.LeftArrow) && !attacking) {
            animator.Play("liz_walk");
            this.GetComponent<SpriteRenderer>().flipX = false;
            this.transform.position -= new Vector3(0.1f, 0, 0);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "shiro") {
            attacking = true;
            AudioSource.PlayClipAtPoint(this.sound, this.transform.position);
            animator.Play("liz_attack");
            shiro.animator.Play("shiro_hurt");
            Global.shiroHealth--;
            bh.GetComponent<RectTransform>().sizeDelta -= new Vector2(100f, 0f);
            bh.GetComponent<RectTransform>().anchoredPosition -= new Vector2(50f, 0);

            if (Global.shiroHealth <= 0)
                lm.LoadLevel("Win");
        }
    }
}
