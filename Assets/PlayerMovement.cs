using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("test");

        transform.position = new Vector3(0.0f, -2.0f, 0.0f);


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Time.deltaTime = time since the last frame
        float maxspeed = 10f;

        if(Input.GetKey("s"))
            {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -2.0f); 
            // if (GetComponent<Rigidbody2D>().velocity.magnitude > maxspeed)
            //     GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity.normalized * maxspeed;
            }
        if(Input.GetKey("a"))
            GetComponent<Rigidbody2D>().velocity = new Vector2(-2.0f, 0.0f); 
         
        if(Input.GetKey("d"))
            GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 0.0f);


        if(Input.GetKey("w"))
            GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 2.0f); 

        if(Input.GetKeyUp("s")) 
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0; 
        }
        if(Input.GetKeyUp("a")) 
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        if(Input.GetKeyUp("d")) 
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        if(Input.GetKeyUp("w")) 
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        if(Input.GetKeyDown("s")) 
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0; 
        }
        if(Input.GetKeyDown("a")) 
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        if(Input.GetKeyDown("d")) 
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        if(Input.GetKeyDown("w")) 
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
        }

    }
}