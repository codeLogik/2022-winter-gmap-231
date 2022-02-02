using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController2DClass : MonoBehaviour
{
    // Variables to allow configuration of script
    public float walkSpeed = 10f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public float groundCheckRadius = .2f;
    public LayerMask groundMask;

    private bool _isGrounded;
    private float _moveInput;
    private float _scaleX;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _scaleX = transform.localScale.x;
    }

    private void Update()
    {
        // Gather input and determine if a jump has performed
        _moveInput = Input.GetAxis("Horizontal");

        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }
    }

    private void FixedUpdate()
    {
        Flip();
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_moveInput * walkSpeed, _rigidbody2D.velocity.y);
    }

    private void Flip()
    {
        if (_moveInput > 0)
        {
            transform.localScale = new Vector3(_scaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (_moveInput < 0)
        {
            transform.localScale = new Vector3(-1 * _scaleX, transform.localScale.y, transform.localScale.z);
        }
    }
}
