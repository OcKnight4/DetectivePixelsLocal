using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollPlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;

    public float jumpForce = 500.0f;

    Rigidbody2D rb;

    SpriteRenderer spriteRenderer;
    Animator animator;

    public bool isGrounded = false;

    public bool shouldJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(horizontalInput, 0, 0) * moveSpeed * Time.deltaTime);

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("isRunning", true);
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            shouldJump = true;
        }
    }
    void FixedUpdate()
    {
        if (shouldJump == true)
        {
            // quickly set back to false so we don't double-jump
            shouldJump = false;

            //push the rigidbody UP
            rb.AddForce(transform.up * jumpForce);
            animator.SetBool("isJumping", true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}


