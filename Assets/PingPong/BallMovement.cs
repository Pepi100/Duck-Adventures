using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 10;
    [SerializeField] private float speedIncrease = 0.25f;
    [SerializeField] private Text playerScore;
    [SerializeField] private Text AIScore;

    private int hitCounter;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();
        Invoke("StartBall", 2f);
    }

    void FixedUpdate()
    {
        rb.velocity =Vector2.ClampMagnitude(rb.velocity, initialSpeed + hitCounter * speedIncrease);
    }

    private void StartBall()
    {
        rb.velocity = new Vector2(-1,0) * (initialSpeed + hitCounter * speedIncrease);
    }

    private void ResetBall()
    {
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
        hitCounter = 0;
        Invoke("StartBall", 2f);
    }

    private void PlayerBounce( Transform myObject)
    {
        hitCounter++;

        Vector2 ballPosition = transform.position;
        Vector2 playerPosition = myObject.position;

        float xDirection, yDirection;

        if(transform.position.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }

        yDirection = (ballPosition.y - playerPosition.y) / myObject.GetComponent<Collider2D>().bounds.size.y;

        if( yDirection == 0)
        {
            yDirection = 0.25f;

        }

        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + hitCounter * speedIncrease);
    }

    private void OnCollisionEnter2D( Collision2D collision)
    {
        if(collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            PlayerBounce(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");
        if(transform.position.x > 0)
        {
            ResetBall();
            playerScore.text = (int.Parse(playerScore.text) + 1).ToString();
        }
        else if(transform.position.x < 0)
        {
            ResetBall();
            AIScore.text = (int.Parse(AIScore.text) + 1).ToString();
        }
    }
}
