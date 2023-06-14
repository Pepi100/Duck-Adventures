using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private bool isAI;
    [SerializeField] private GameObject ball;


    private Rigidbody2D rb;
    private Vector2 playerMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAI)
        {
            AIControl();
        }
        else
        {
            PlayerControl();

        }
    }

    private void PlayerControl()
    {
        playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
    }

    private void AIControl()
    {
        if(ball.transform.position.y > transform.position.y + 1f)
        {
            playerMove = new Vector2(0, 1);
        }
        else if(ball.transform.position.y < transform.position.y - 1f) // 
        {
            playerMove = new Vector2(0, -1);
        }
        else 
        {
            playerMove = new Vector2(0, 0);
        }
    
    }

    private void FixedUpdate()
    {
        rb.velocity = playerMove * movementSpeed;
    }
}
