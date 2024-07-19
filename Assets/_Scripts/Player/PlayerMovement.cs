using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Joystick joystick;
    
    private Animator _animator;
    private Rigidbody2D _rb;
    private Vector2 _moveInput;
    private Vector2 _moveVelocity;

    public static bool _facingRight = true;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _moveInput = new Vector2(joystick.Direction.x, joystick.Direction.y);
        _moveVelocity = _moveInput.normalized * speed;

        if (_moveVelocity.x != 0 || _moveVelocity.y != 0)
        {
            _rb.MovePosition(_rb.position + _moveVelocity * Time.fixedDeltaTime);
        }
        _animator.SetFloat("Speed", _moveInput.magnitude);

        if (!_facingRight && _moveInput.x > 0)
        {
            Flip();
        }else if (_facingRight && _moveInput.x < 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
