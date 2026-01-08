using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private float _moveSpeed = 250f;
    private float _horizontalInput;
    private float _jumpForce = 35f;
    private bool _isGrounded = false;
    private bool _isFacingRight = true; // Set default value according to sprite.
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal"); // Needs to update to new Input System
        FlipSprite();
        if (!Input.GetButtonDown("Jump") || !_isGrounded) return; // Needs to update to new Input System
        _isGrounded = false;
        _rb.AddForceY(_jumpForce, ForceMode2D.Impulse);
        _animator.SetBool("isJumping", !_isGrounded);
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = _horizontalInput * _moveSpeed * Time.fixedDeltaTime;
        _animator.SetFloat("xVelocity", Math.Abs(_rb.linearVelocityX));
        _animator.SetFloat("yVelocity", _rb.linearVelocityY);
    }
    
    private void FlipSprite()
    {
        if ((!(_horizontalInput > 0) || _isFacingRight) && (!(_horizontalInput < 0) || !_isFacingRight)) return;
        _isFacingRight = !_isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _isGrounded = true;
        _animator.SetBool("isJumping", !_isGrounded);
    }
}
