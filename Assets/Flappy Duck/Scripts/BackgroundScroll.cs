using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{



    public float speed = 1f;
    private Vector3 StartPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left*speed*Time.deltaTime);
        if (transform.position.x < -17f)
        {
            transform.position = StartPosition;
        }
    }
}
