using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D _rg;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpSpeed = 2f;
    public Animator _anim;
    CapsuleCollider2D capcol;
    void Start()
    {
        _rg = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        capcol = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnJump(InputValue value)
    {
        if (!capcol.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (value.isPressed)
        {
            _rg.velocity += new Vector2(0f, jumpSpeed);
        }
    }
    void ClimbLadder(InputValue value)
    {
        if (!capcol.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }
        if (value.isPressed)
        {
            Vector2 playerVelocity = new Vector2(_rg.velocity.x, moveInput.y * moveSpeed);
        }
    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, _rg.velocity.y);
        _rg.velocity = playerVelocity;
        bool PlayerHasHorizontalSpeed = Mathf.Abs(_rg.velocity.x) > Mathf.Epsilon;
        _anim.SetBool("IsRunning", PlayerHasHorizontalSpeed);
    }
    void FlipSprite()
    {
        bool PlayerHasHorizontalSpeed = Mathf.Abs(_rg.velocity.x) > Mathf.Epsilon;
        if (PlayerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rg.velocity.x), 1f);
        }
    }
}
