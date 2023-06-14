using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 touchStartPosition;
    private bool isTouching;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Store the touch start position
                touchStartPosition = touch.position;
                isTouching = true;
            }
            else if (touch.phase == TouchPhase.Moved && isTouching)
            {
                // Calculate the touch movement distance
                float touchDelta = touch.position.y - touchStartPosition.y;

                // Move the player's paddle based on the touch movement
                Vector2 currentPosition = rb.position;
                currentPosition.y += touchDelta / Screen.height * movementSpeed;
                rb.MovePosition(currentPosition);
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                // Reset the touch state
                isTouching = false;
            }
        }
        else
        {
            // Reset the touch state
            isTouching = false;
        }
    }
}
