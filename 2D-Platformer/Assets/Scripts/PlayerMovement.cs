using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _moveSpeed = 500f;
    private float _horizontalInput;
    private float _jumpForce = 2f;
    private bool _isJumping = false;
    private bool _isFacingRight = false; // Set default value according to sprite.
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal"); // Needs to update to new Input System
        FlipSprite();
        if (!Input.GetButtonDown("Jump") || _isJumping) return; // Needs to update to new Input System
        _isJumping = true;
    }

    private void FixedUpdate()
    {
        _rb.linearVelocityX = _horizontalInput * _moveSpeed * Time.fixedDeltaTime;
        if (_isJumping) _rb.linearVelocityY = _jumpForce;
    }
    
    private void FlipSprite()
    {
        if ((!(_horizontalInput > 0) || _isFacingRight) && (!(_horizontalInput < 0) || !_isFacingRight)) return;
        _isFacingRight = !_isFacingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isJumping = false;
    }
}
