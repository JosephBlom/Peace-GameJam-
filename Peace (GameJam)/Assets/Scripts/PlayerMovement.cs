using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables")]
    [Tooltip("Sets the current object to player 1. (Only Have 1 Player 1!)")]
    public bool p1;
    [Tooltip("Sets the players movement speed")]
    public int moveSpeed = 1;
    [Tooltip("Sets the players jump height")]
    public int jumpHeight = 1;
    [SerializeField] Transform groundedRay;
    [SerializeField] Animator animator;

    public InputAction playerControls;

    Vector2 moveInput;
    Rigidbody2D rb;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = playerControls.ReadValue<Vector2>();
        Move();
        flipSprite();
    }

    void flipSprite()
    {
        bool playerHaseHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHaseHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
        bool playerHaseHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHaseHorizontalSpeed)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.W) && p1)
        {
            RaycastHit2D ray = Physics2D.Raycast(groundedRay.position, Vector2.down, 0.1f);
            if (ray)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && !p1)
        {
            RaycastHit2D ray = Physics2D.Raycast(groundedRay.position, Vector2.down, 0.1f);
            if (ray)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
        }
    }
}
