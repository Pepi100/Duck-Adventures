using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Bullet laserPrefab;

    public float speed = 5.0f;

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

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    

}
