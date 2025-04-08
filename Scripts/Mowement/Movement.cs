using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : Sounds
{

    private float _moveDir;
    public float jumpHeight;
    public float moveSpeed = 10f;
    private bool _jumpPressed;
    private float _jumpYVel;
    private Rigidbody2D _rigidbody2D;
    private Vector3 _moveVel;
    private bool IsGrounded;



    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        Move();
        HandleJump();
    }

    private void HandleJump()
    {
        if (IsGrounded && _jumpPressed)
        {
            PlaySound(sounds[0]);
            _jumpYVel = CalculateJumpVel(jumpHeight);
            _jumpPressed = false;

            _moveVel = _rigidbody2D.velocity;
            _moveVel.y = _jumpYVel;
            _rigidbody2D.velocity = _moveVel;
        }

    }

    private void Move()
    {
        _moveVel = _rigidbody2D.velocity;
        _moveVel.x = _moveDir * moveSpeed * Time.fixedDeltaTime;
        _rigidbody2D.velocity = _moveVel;
    }


    private float CalculateJumpVel(float height)
    {
        return MathF.Sqrt((-2 * _rigidbody2D.gravityScale * Physics2D.gravity.y * height));
    }

    void GetInput()
    {
        _moveDir = Input.GetAxisRaw("Horizontal");
        _jumpPressed |= Input.GetKeyDown(KeyCode.Space);
        
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        IsGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        IsGrounded = false;
    }

}
