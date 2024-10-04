using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_controller : MonoBehaviour
{
    private Vector2 movementVector;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    public float jumpForce = 5f;  // Adjust the jump force as needed

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(movementVector.x, rb.velocity.y);  // Maintain vertical velocity during movement
    }

    // Movement input handling
    void OnMove(InputValue value)
    {
        movementVector = value.Get<Vector2>() * 10;
        Debug.Log(movementVector);
    }

    // Jump input handling
    void OnJump(InputValue value)
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;  // Prevent jumping again until grounded
        }
    }

    // Check collision to determine if grounded
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("IsGround");
        }
    }
}
