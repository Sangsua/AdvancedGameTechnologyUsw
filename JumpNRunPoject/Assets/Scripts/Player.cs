using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 19f;
    float xDirection;
    public float maxSpeed = 8f;
    public float jumpforce = 300f;
    public int jumpcount=0;
    public bool isDead;
    public bool grounded;

    private Rigidbody2D rb;
    private Animator anim;

	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
	}

    private void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        anim.SetBool("grounded", grounded);
        anim.SetBool("isDead",isDead);
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y <= 0.001 && jumpcount == 0)

        {

            rb.AddForce(new Vector2(0f, jumpforce));
        }
        Death();

    }
    void FixedUpdate () {
        SetSpeed();
        PlayerMovement();
      
	}

    void PlayerMovement()
    {
        if (!isDead) {

          
            //Walking

            if (Input.GetKey(KeyCode.LeftArrow))

            {

                transform.localScale = new Vector3(-1, 1, 1);
                rb.AddForce(new Vector2(-1f * speed, 0f));
            }

            if (Input.GetKey(KeyCode.RightArrow))

            {

                transform.localScale = new Vector3(1, 1, 1);
                rb.AddForce(new Vector2(1f * speed, 0f));
            }

        }

    }

    void SetSpeed()
    {
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }
        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }
    }
    void Death()
    {
   
        if (isDead)
        {
            
            transform.position += Vector3.up * Time.deltaTime * 0.5f ;
            rb.gravityScale = 0;
        }
    }
}
