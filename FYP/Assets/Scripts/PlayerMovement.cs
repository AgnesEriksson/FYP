using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float jumpForce = 10f;
    private float IncreaseForceRate = 5f;
    private float jumpCooldown = 0.5f;
    private float timeSinceJump;
    private float groundDistance = 0.2f;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private Transform groundCheck;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool canJump = true;
    private bool isJumping = false;
    private float currentJumpForce;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundLayer);


        if (isGrounded && canJump && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetKeyDown(KeyCode.W))
        {
            if (jumpCooldown < timeSinceJump)
            {
                rb.velocity = Vector2.up * jumpForce;
                timeSinceJump += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.W)) 
        {
            isJumping = false;
            timeSinceJump = 0;
        }
    }
}
