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


        if( Input.GetKey("d") )
        {
            rb.AddForce(transform.right * 100 * Time.deltaTime);

        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(transform.right *-100 * Time.deltaTime);

        }


        if (Input.GetKey("w"))
        {
            rb.AddForce(transform.up * 100 * Time.deltaTime);

        }

        if (Input.GetKey("s"))
        {
            rb.AddForce(transform.up * -100 * Time.deltaTime);

        }

    }
}
