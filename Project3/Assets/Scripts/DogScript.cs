using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogScript : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator anim;
    public float xSpeed= 5f;
    public float jumpforce = 500f;
    private bool isDead = false;
    private bool isGrounded;
    private bool isJumping;


	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)){
            isJumping = true;
        }
    }
    private void FixedUpdate()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        if (!isDead)
        {
        if (isJumping)
        {
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0f, jumpforce));
                anim.SetTrigger("TriggerJumping");
                isJumping = false;
        }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        anim.SetBool("isDead", isDead);
        GameController.instance.GameOver();

    }

}
