using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController2D : MonoBehaviour
{
    public float walkSpeed = 4f;
    public float jumpForce = 8f;
    public Transform groundCheck;
    public float groundCheckRadius = .2f;
    public LayerMask groundMask;

    public Animator animator;

    private bool _isGrounded;
    private float _moveInput;
    private float _scaleX;
    private Rigidbody2D _rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");

        animator.SetBool("Grounded", _isGrounded);
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Flip();
        Move();
    }

    private void Flip()
    {
        if (_moveInput < 0)
        {
            transform.localScale = new Vector3(-1 * _scaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (_moveInput > 0)
        {
            transform.localScale = new Vector3(_scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_moveInput * walkSpeed, _rigidbody.velocity.y);
        animator.SetFloat("MoveSpeed", Mathf.Abs(_moveInput));
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
    }
}
