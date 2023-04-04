using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("destroyed obstacles");
        }
    }
}
