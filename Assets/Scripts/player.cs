using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {
    public bool canJump = false;
    bool jump;
    public Rigidbody2D rb;
    public float jumpForce = 0f;
    public float fallSpeed = 0f;
    public float lowJumpMultiplier = 0f;
    public float distance = 0;
    public float gravityScaleReset = 1f;
    LevelMovement levelRef;
    // Use this for initialization

    void Start ()
    {
        levelRef = FindObjectOfType<LevelMovement>();
	}

    // Update is called once per frame
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.collider != null)
        {
            distance = Vector2.Distance(hit.point, transform.position);
            if (distance <= 2f)
            {
                canJump = true;
            }
            else
            {
                canJump = false;
            }
        }

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

        if (jump && canJump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
        if(rb.velocity.y < 0)
        {
            rb.gravityScale = fallSpeed;
        } else if (rb.velocity.y > 0 && Input.touchCount <= 0)
        {
            rb.gravityScale = lowJumpMultiplier;
        } else
        {
            rb.gravityScale = gravityScaleReset;
        }
    }

    void GameOver()
    {
        PlayerPrefs.SetInt("score", levelRef.currentScore);
        SceneManager.LoadScene(2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Obstacle")
        {
            GameOver();
        }
    }
}
