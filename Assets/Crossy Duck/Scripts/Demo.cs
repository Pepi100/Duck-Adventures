using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;

public class Demo : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float playerSpeed;

    private Vector2 playerDirection = Vector2.zero;
    private SpriteRenderer spriteRenderer; 
    private Vector3 spawnPosition;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spawnPosition = transform.position;
    }

    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    private void OnSwipe(string swipe)
    {
        //Debug.Log(swipe);                 
        switch(swipe)
        {
            case "Left":
                transform.localScale = new Vector3(0.4f, 0.4f, 1f);
                Move(Vector3.left);
                //newPosition += Vector3.left;
                break;
            case "Right":
                transform.localScale = new Vector3(-0.4f, 0.4f, 1f);
                Move(Vector3.right);
                //newPosition += Vector3.right;
                break;
            case "Up":
                transform.localScale = new Vector3(transform.localScale.x, 0.4f, 1f);
                Move(Vector3.up);
                //newPosition += Vector3.up;
                break;
            case "Down":
                transform.localScale = new Vector3(transform.localScale.x, 0.4f, 1f);
                Move(Vector3.down);
                //newPosition += Vector3.down;
                break;
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


    // private void Update()
    // {
    //     playerTransform.position += (Vector3) playerDirection * playerSpeed * Time.deltaTime;
    // }

    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}
