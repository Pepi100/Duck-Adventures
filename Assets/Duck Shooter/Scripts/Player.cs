using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Bullet laserPrefab;

    public Rigidbody2D rb;

    public float speed = 5.0f;

    private bool _bulletActive;

    bool facingLeft = false;

    float inputHorizontal;
    float inputVertical;

    public Animator animator;
    public AudioSource audioSrc;

    private void BulletDestroyed()
    {
        _bulletActive = false;
    }



    private void Shoot()
    {
        if (!_bulletActive)
        {
            Bullet bullet = Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
            bullet.destroyed += BulletDestroyed;
            _bulletActive = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy") || other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            SceneManager.LoadScene("Lose");
        }
    }

    private void Update()
    {
        float maxx;
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSrc.Play();
            Shoot();

        }

        maxx = Mathf.Abs(inputHorizontal);
        animator.SetFloat("speed", maxx);
    }

    void FixedUpdate()
    {
        if (inputHorizontal > 0 && facingLeft)
        {
            Flip();
        }
        if (inputHorizontal < 0 && !facingLeft)
        {
            Flip();
        }

    }

    void Flip()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        Vector3 currentScale = player.transform.localScale;
        currentScale.x *= -1;
        player.transform.localScale = currentScale;
        facingLeft = !facingLeft;
    }



}
