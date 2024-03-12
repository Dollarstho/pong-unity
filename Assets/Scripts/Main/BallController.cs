using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;
    public Vector2 startingVelocity = new Vector2(5f, 5f);
    public GameManager gameManager;
    public float speedUp = 1.15f;

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if(rb == null) rb = GetComponent<Rigidbody2D>();
        rb.velocity = startingVelocity;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.velocity;

            newVelocity.y = -newVelocity.y;
            rb.velocity = newVelocity;
        }

        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
             rb.velocity *= speedUp;
        }

        if (collision.gameObject.CompareTag("WallPlayer2"))
        {
            gameManager.ScorePlayer1();
            ResetBall();
        }
        if (collision.gameObject.CompareTag("WallPlayer1"))
        {
            gameManager.ScorePlayer2();
            ResetBall();
        }
    }
   
}
