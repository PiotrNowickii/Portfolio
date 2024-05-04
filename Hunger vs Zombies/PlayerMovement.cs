using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public bool isFacingRight;
    public bool isFacingUp;
    public bool isFacingLeft;
    public bool isFacingDown;
    [SerializeField] private Rigidbody2D _rb;
    private Vector2 _movement;
    [SerializeField] private Animator _animator;

    
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            isFacingUp = true;
            isFacingDown = false;
            _animator.SetBool("isFacingUp", true);
            _animator.SetBool("isFacingDown", false);
            _animator.SetBool("isWalking", true);
            _animator.SetBool("isIdle", false);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
                isFacingUp = false;
                isFacingDown = true;
                _animator.SetBool("isFacingUp", false);
                _animator.SetBool("isFacingDown", true);
                _animator.SetBool("isWalking", true);
                _animator.SetBool("isIdle", false);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            isFacingRight = true;
            isFacingLeft = false;
            _animator.SetBool("isFacingRight", true);
            _animator.SetBool("isFacingLeft", false);
            _animator.SetBool("isWalking", true);
            _animator.SetBool("isIdle", false);
        }
            
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            isFacingRight = false;
            isFacingLeft = true;
            _animator.SetBool("isFacingRight", false);
            _animator.SetBool("isFacingLeft", true);
            _animator.SetBool("isWalking", true);
            _animator.SetBool("isIdle", false);
        }
        if (Input.GetAxisRaw("Horizontal") == 0 && (isFacingUp || isFacingDown))
        {
            isFacingRight = false;
            isFacingLeft = false;
            _animator.SetBool("isFacingRight", false);
            _animator.SetBool("isFacingLeft", false);
            
        }
        if (Input.GetAxisRaw("Vertical") == 0 && (isFacingLeft || isFacingRight))
        {
            isFacingUp = false;
            isFacingDown = false;
            _animator.SetBool("isFacingUp", false);
            _animator.SetBool("isFacingDown", false);
            
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            _animator.SetBool("isIdle", true);
            _animator.SetBool("isWalking", false);
        }
            
        
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * moveSpeed * Time.fixedDeltaTime);
        //_rb.velocity = new Vector2(_movement.x, _movement.y);
    }
}
