using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController2D_Old : MonoBehaviour
{
    // Variables to allow configuration of script
    public float jumpForce = 400f;
    public float walkSpeed = 2000f;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundedRadius = .2f;
    public LayerMask groundMask;

    private Rigidbody2D _rigidbody2D;
    // private Vector3 _velocity = Vector3.zero;
    private bool _facingRight = true;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // STore off our isGrounded value, reset it to false, and test to see if we are grounded.
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, groundMask);

        foreach (var collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                isGrounded = true;
            }
        }
    }

    public void Move(float move, bool jump)
    {
        if (isGrounded)
        {
            Vector2 targetVelocity = new Vector2(move * walkSpeed, _rigidbody2D.velocity.y);

            _rigidbody2D.velocity = targetVelocity;

            // Determine if we need to flip the character around.
            if (move > 0 && !_facingRight)
            {
                Flip();
            }
            else if (move < 0 && _facingRight)
            {
                Flip();
            }

            // Handle adding a jump force if one has been supplied.
            if (isGrounded && jump)
            {
                isGrounded = false;
                _rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            }
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
