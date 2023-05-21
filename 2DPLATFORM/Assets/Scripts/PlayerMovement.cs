using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float inputDirection;
    public float speed;
    private Rigidbody2D rb;
    public float jumpPower;
    private SpriteRenderer sr;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }
    private void FixedUpdate()
    {
        Movement();
    }


    private void CheckInput()
    {
        inputDirection = Input.GetAxisRaw("Horizontal");
        if (inputDirection > 0)
        {
            sr.flipX = false;
        }
        else if (inputDirection<0)
        {
            sr.flipX = true;
        }
        if (Input.GetButtonDown("Jump") && GroundCheck.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
    private void Movement()
    {
        rb.velocity = new Vector2(speed * inputDirection, rb.velocity.y);
        if (rb.velocity.x != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }
}
