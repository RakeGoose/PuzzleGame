using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float speedX = rb.velocity.x;
        float speed = Mathf.Abs(speedX);
        anim.SetFloat("Speed", speed);

        anim.SetBool("isJumping", !IsGrounded());

        bool isFalling = rb.velocity.y < -0.1f && !IsGrounded();
        anim.SetBool("isFalling", isFalling);

        if(speedX > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if(speedX < -0.01f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }
}
