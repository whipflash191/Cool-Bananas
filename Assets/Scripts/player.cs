using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
    public bool canJump = false;
    bool jump;
    Rigidbody2D rb;
    public float jumpForce = 0;
    [Range(0, 1000)]
    public float maxJumpHeight;
    public float currentMaxJumpHeight;
    [Range(0, 100)]
    public float climbRate;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        currentMaxJumpHeight = maxJumpHeight;
	}

    // Update is called once per frame
    private void Update()
    { 
        if (Input.touchCount > 0)
        {
            jump = true;
        } else
        {
            jump = false;
        }
    }
    void FixedUpdate ()
    {
        if (jump)
        {
            if (currentMaxJumpHeight > 0)
            {
                currentMaxJumpHeight -= climbRate;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            currentMaxJumpHeight = maxJumpHeight;
            canJump = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            canJump = false;
        }
    }
}
