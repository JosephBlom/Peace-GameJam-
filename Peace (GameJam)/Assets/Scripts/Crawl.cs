using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawl : MonoBehaviour
{
    public float crawlSpeed = 2f;
    private bool isCrawling = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleCrawl();
    }

    void HandleCrawl()
    {
        bool isCrawlKeyPressed = Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow));

        if (isCrawlKeyPressed)
        {
            isCrawling = true;
        }
        else
        {
            isCrawling = false;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        if (isCrawling)
        {
            rb.velocity = new Vector2(horizontalInput * crawlSpeed, rb.velocity.y);
        }
    }
}
