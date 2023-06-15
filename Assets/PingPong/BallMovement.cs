using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
        float xDirection = Random.Range(0,2) == 0 ? -1 : 1;
        float yDirection = Random.Range(0,2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + hitCounter * speedIncrease);
        ///rb.velocity = new Vector2(-1,0) * (initialSpeed + hitCounter * speedIncrease);
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

    //function for making the ball bounce off top and down border without scoring
    private void BounceOffBorder()
    {
        Vector2 currentVelocity = rb.velocity;
        rb.velocity = new Vector2(currentVelocity.x, -currentVelocity.y);
    }

    private void OnCollisionEnter2D( Collision2D collision)
    {
        if(collision.gameObject.name == "Player" || collision.gameObject.name == "AI")
        {
            PlayerBounce(collision.transform);
        }
        else if(collision.gameObject.name == "TopBorder" || collision.gameObject.name == "BottomBorder")
        {
            //rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            BounceOffBorder();
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

        if(playerScore.text == "3")
        {
            if( AIScore.text == "0")
            {
                PlayerData.instance.Add(1);
            }
            PlayerData.instance.DoneMinigame(2);
            playerScore.text = "0";
            AIScore.text = "0";
            SceneManager.LoadScene("Win3");
        }
        else if(AIScore.text == "3")
        {
            playerScore.text = "0";
            AIScore.text = "0";
            SceneManager.LoadScene("Lose3");
        }
    }

}
