using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f; // Force Apllied to jump
    [SerializeField] private float jumpTime = 0.5f; //The time allowed for the jump to apply force
    [SerializeField] private Transform Sprite; // The Component storing the Sprite Renderer
    [SerializeField] private float crouchScale = 0.5f; //Scaleing for Sprite when crouching
    private float timeSinceJump; //Timer for jumptime
    private float groundDistance = 0.2f; // Max distance allowed to be away from the ground to jump

    [SerializeField]
    private LayerMask groundLayer; //ground Layer
    [SerializeField]
    private Transform groundCheck; // Sphere to check distance to anyhting Ground Layer

    private Rigidbody2D rb;
    private bool isGrounded; //bool for grounding
    private bool canJump = true;
    private bool isJumping = false; // bools for jump conditions 
    private bool isCrouching = false; //bool for crouching

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // fetching the rb rather than serializing the field
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundDistance, groundLayer); //ground checking

        #region Jump Code (W)
        if (isGrounded && canJump && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce; //applys jumping force if player is grounded
        }

        if (isJumping && Input.GetKey(KeyCode.W)) //while key is pressed 
        {
            if (jumpTime > timeSinceJump) //continues to apply jump force
            {
                rb.velocity = Vector2.up * jumpForce;
                timeSinceJump += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.W)) //end of jump input
        {
            isJumping = false;
            timeSinceJump = 0;
        }
        #endregion
        #region Crouch Code (S)
        if (isGrounded && Input.GetKeyDown(KeyCode.S))
        {
            isCrouching = true;
            Sprite.localScale = new Vector3 (Sprite.localScale.x, crouchScale, Sprite.localScale.z);
            if (isJumping)
            {
                Sprite.localScale = new Vector3(Sprite.localScale.x, 1f , Sprite.localScale.y);
            }
        }
        if (isCrouching && Input.GetKey(KeyCode.S))
        {
            Sprite.localScale = new Vector3(Sprite.localScale.x, crouchScale, Sprite.localScale.z);
        }
        if (isCrouching && Input.GetKeyUp(KeyCode.S))
        {
            isCrouching = false;
            Sprite.localScale = new Vector3(Sprite.localScale.x, 1f , Sprite.localScale.z);
        }
        #endregion
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("test");
        if (collision.gameObject.CompareTag("Danger"))
        {
            GameManager.Instance.gameOver = true;
            GameManager.Instance.isPlaying = false;
        }
    }

}
