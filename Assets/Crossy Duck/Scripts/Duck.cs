using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private SpriteRenderer spriteRenderer; 

    public Sprite deadSprite;

    private Vector3 spawnPosition;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPosition = transform.position;
    }

    //e chemata pe la fiecare frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.4f, 1f);
            Move(Vector3.up);
        }

        if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.4f, 1f);
            Move(Vector3.down);
        }

        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 1f);
            Move(Vector3.left);
        }

        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
            Move(Vector3.right);
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 destination = transform.position + direction;

        Collider2D barrier = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
        Collider2D platform = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Platform"));
        Collider2D obstacle = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));
        Debug.Log(barrier);
        Debug.Log(platform);
        Debug.Log(obstacle);
        if(barrier != null)
        {
            return;
        }

        if(platform != null)
        {
            transform.SetParent(platform.transform);
            // Vector3 localScale = transform.localScale;
            // localScale.x = 0.4f;
            // localScale.y = 0.4f;
            // localScale.z = 1f;
            // transform.localScale = localScale;
        }
        else{
            transform.SetParent(null);
        }

        if(obstacle != null && platform == null)
        {
            transform.position = destination;
            Death();
        }
        else 
        {
            StartCoroutine(Leap(destination));
        }
    }

    private IEnumerator Leap(Vector3 destination)
    {
        Vector3 startPosition = transform.position;
        
        float elapsed = 0f;
        float duration = 0.125f;

        while(elapsed < duration)
        {
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(startPosition, destination, t);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = destination;
    }

    public void Death()
    {
        StopAllCoroutines();

        spriteRenderer.sprite = deadSprite;
        enabled = false;

        FindObjectOfType<GameManager>().Died();
    }

    public void Respawn()
    {
        StopAllCoroutines();

        transform.position = spawnPosition;
        gameObject.SetActive(true);
        enabled = true;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(enabled && other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && transform.parent == null)
        {
            Death();
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using GG.Infrastructure.Utils.Swipe;

// public class Duck : MonoBehaviour
// {
//     private SpriteRenderer spriteRenderer;
//     private Vector3 spawnPosition;


//     [SerializeField] private SwipeListener swipeListener;
//     [SerializeField] private float swipeMovementSpeed = 1f;

//     private void Awake()
//     {
//         spriteRenderer = GetComponent<SpriteRenderer>();
//         spawnPosition = transform.position;
//         swipeListener.OnSwipe.AddListener(OnSwipe);
//     }

//     private void OnSwipe(string swipe)
//     {
//         Debug.Log(swipe);
//         Vector3 swipeDirection = Vector3.zero;

//         switch (swipe)
//         {
//             case "Left":
//                 swipeDirection = Vector3.left;
//                 break;
//             case "Right":
//                 swipeDirection = Vector3.right;
//                 break;
//             case "Up":
//                 swipeDirection = Vector3.up;
//                 break;
//             case "Down":
//                 swipeDirection = Vector3.down;
//                 break;
//         }

//         Move(swipeDirection);
//     }

//     private void Move(Vector3 direction)
//     {
//         Vector3 destination = transform.position + direction;

//         Collider2D barrier = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Barrier"));
//         Collider2D platform = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Platform"));
//         Collider2D obstacle = Physics2D.OverlapBox(destination, Vector2.zero, 0f, LayerMask.GetMask("Obstacle"));

//         if (barrier != null)
//         {
//             return;
//         }

//         if (platform != null)
//         {
//             transform.SetParent(platform.transform);
//         }
//         else
//         {
//             transform.SetParent(null);
//         }

//         if (obstacle != null && platform == null)
//         {
//             transform.position = destination;
//             Death();
//         }
//         else
//         {
//             StartCoroutine(Leap(destination));
//         }
//     }

//     private IEnumerator Leap(Vector3 destination)
//     {
//         Vector3 startPosition = transform.position;

//         float elapsed = 0f;
//         float duration = swipeMovementSpeed;

//         while (elapsed < duration)
//         {
//             float t = elapsed / duration;
//             transform.position = Vector3.Lerp(startPosition, destination, t);
//             elapsed += Time.deltaTime;
//             yield return null;
//         }

//         transform.position = destination;
//     }

//     public void Death()
//     {
//         StopAllCoroutines();
//         enabled = false;

//         FindObjectOfType<GameManager>().Died();
//     }

//     public void Respawn()
//     {
//         StopAllCoroutines();

//         transform.position = spawnPosition;
//         gameObject.SetActive(true);
//         enabled = true;
//     }

//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (enabled && other.gameObject.layer == LayerMask.NameToLayer("Obstacle") && transform.parent == null)
//         {
//             Death();
//         }
//     }

//     private void OnDisable()
//     {
//         swipeListener.OnSwipe.RemoveListener(OnSwipe);
//     }
// }

