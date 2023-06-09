using UnityEngine;
using UnityEngine.SceneManagement;
using GG.Infrastructure.Utils.Swipe;

public class Player : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;

    public Bullet laserPrefab;

    public float speed = 40.0f;

    private bool _bulletActive;

    private void BulletDestroyed()
    {
        _bulletActive = false;
    }

    private void Shoot()
    {
        if(! _bulletActive)
        {
            Bullet bullet = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            bullet.destroyed += BulletDestroyed;
            _bulletActive = true;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            SceneManager.LoadScene("Lose");
        }
    }

    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }

    private void OnSwipe(string swipe)
    {
        Debug.Log(swipe); 
         
        switch(swipe)
        {
            case "Left":
                this.transform.position += Vector3.left * this.speed * Time.deltaTime;
                break;
            case "Right":
                this.transform.position += Vector3.right * this.speed * Time.deltaTime;
                break;
            default:
                Shoot();
                break;
        }
        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        // {
        //     Shoot();
        // }
    }

    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }

}
