using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float velocity = 1;

    // Start is called before the first frame update
    void Start()
    {

        rb.velocity = Vector2.up * velocity;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) )
        {
            //jump
            rb.velocity = Vector2.up * velocity;


        }



        
    }
}
