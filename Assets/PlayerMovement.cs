using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public Joystick joystick; 
    float inputHorizontal;
    float inputVertical;
    public AudioSource audioSrc;

    //player
    float speed = 8f;
    float speedLimiter = 0.7f;
    bool facingLeft = false;
    bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 100;
        PlayerData pd = PlayerData.instance;
        transform.position = new Vector3(pd.getX(), pd.getY(), pd.getZ());
        Debug.Log(transform.position);
        Debug.Log(pd.getIslandNumber());

        ///set screen landscape
        ScreenChanger.instance.SetLandscape();
    }


    void Update()
    {
        float maxx;
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");
        
        /*for mobile*/
        inputHorizontal = joystick.Horizontal;
        inputVertical = joystick.Vertical;
        if (Mathf.Abs(inputVertical) > Mathf.Abs(inputHorizontal))
            maxx = Mathf.Abs(inputVertical);
        else
            maxx = Mathf.Abs(inputHorizontal);
        animator.SetFloat("speed", maxx);
        if (maxx > 0)
            isMoving = true;    
        else
            isMoving = false;   
        if (isMoving)
        {
            if (!audioSrc.isPlaying)
                audioSrc.Play();
        }
        else
            audioSrc.Stop();
    }


    void FixedUpdate()
    {
        if (inputHorizontal != 0 || inputVertical != 0)
        {
            if(inputHorizontal != 0 && inputVertical != 0)
            {
                inputHorizontal *= speedLimiter;
                inputVertical *= speedLimiter;
            }
            rb.velocity = new Vector2(inputHorizontal * speed, inputVertical * speed);
        }
        else
        {
            rb.velocity = new Vector2(0f, 0f);
        }

        if (inputHorizontal > 0 && facingLeft)
        {
            Flip();
        }
        if (inputHorizontal < 0 && !facingLeft)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingLeft = !facingLeft;
    }

}
