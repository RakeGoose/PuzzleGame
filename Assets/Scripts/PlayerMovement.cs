using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isBreakablePlatform;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;
    public LayerMask breakableLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        isBreakablePlatform = Physics2D.OverlapCircle(groundCheck.position, checkRadius, breakableLayer);

        if((Input.GetButtonDown("Jump") && isGrounded) || (Input.GetButtonDown("Jump") && isBreakablePlatform))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
