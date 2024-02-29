using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    public float wallJumpForce = 10f;
    public float wallSlideSpeed = 2f;
    public float wallCheckDistance = 0.1f;
    private bool isTouchingWall;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        HandleWallJump();
    }

    void HandleWallJump()
    {
        isTouchingWall = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, wallCheckDistance);

        if (isTouchingWall)
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }

        if (Input.GetKeyDown(KeyCode.Space) && isTouchingWall)
        {
            rb.velocity = new Vector2(-transform.localScale.x * wallJumpForce, wallJumpForce);
        }
    }
}
