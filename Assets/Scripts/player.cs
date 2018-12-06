using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {
    public bool canJump = false;
    bool jump;
    public Rigidbody2D rb;
    public float jumpForce = 0;
    [Range(0, 1000)]
    public float maxJumpHeight;
    public float currentMaxJumpHeight;
    [Range(0, 100)]
    public float climbRate;
    LevelMovement levelRef;
    // Use this for initialization

    void Start ()
    {
        currentMaxJumpHeight = maxJumpHeight;
        levelRef = FindObjectOfType<LevelMovement>();
	}

    // Update is called once per frame
    private void Update()
    { 
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Stationary:
                    climbRate = 25f;
                    break;
                case TouchPhase.Began:
                    climbRate = 50f;
                    break;
            }
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

    void GameOver()
    {
        PlayerPrefs.SetInt("score", levelRef.currentScore);
        SceneManager.LoadScene(2);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tile")
        {
            currentMaxJumpHeight = maxJumpHeight;
            canJump = true;
        }

        if(collision.gameObject.tag == "Obstacle")
        {
            GameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tile")
        {
            canJump = false;
        }
    }
}
