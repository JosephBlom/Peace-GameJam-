using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Variables")]
    [Tooltip("Sets the current object to player 1. (Only Have 1 Player 1!)")]
    public bool p1;
    [Tooltip("Sets the players movement speed")]
    public int moveSpeed = 1;
    [Tooltip("Sets the players jump height")]
    public int jumpHeight = 1;

    Vector2 moveInput;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (p1)
        {
            p1Move();
        }
        else
        {
            p2Move();
        }
    }

    void OnMove()

    void p1Move()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, rb2d.velocity.y);
            rb2d.velocity = playerVelocity;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity += new Vector2(rb.velocity.x, 1 * jumpHeight * Time.deltaTime);
        }
    }
    void p2Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-1 * moveSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(1 * moveSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity += new Vector2(rb.velocity.x, 1 * jumpHeight * Time.deltaTime);
        }
    }
}
