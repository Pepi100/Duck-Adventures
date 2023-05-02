using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    public Enemy[] prefabs;

    public int rows = 4;

    public int columns = 7;

    public AnimationCurve speed;

    public Bullet bulletPrefab;

    public float bulletAttackRate = 1.0f;

    private Vector3 _direction = Vector2.right;

    public int amountKilled {get; private set;}

    public int amountAlive => this.totalEnemies - this.amountKilled;

    public int totalEnemies => this.rows * this.columns;

    public float percentKilled => (float)this.amountKilled / (float)this.totalEnemies;

    private void EnemyKilled()
    {
        this.amountKilled++; 
        if(this.amountKilled >= this.totalEnemies)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void Awake()
    {
        for(int row = 0; row < this.rows; row++)
        {
            float width = 3.0f * (this.columns - 1);
            float height = 3.0f * (this.rows - 1);
            Vector2 centering = new Vector2(-width / 2, -height / 2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y + (row * 3.0f), 0.0f);
            for(int col = 0; col < this.columns; col++)
            {
                Enemy enemy = Instantiate(this.prefabs[row], this.transform);
                enemy.killed += EnemyKilled;
                Vector3 position = rowPosition;
                position.x += col * 3.0f;
                enemy.transform.localPosition = position; 
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 1.0f;
        this.transform.position = position;
    }

    private void BulletAttack()
    {
        foreach(Transform enemy in this.transform)
        {
            if(!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(Random.value < (1.0f / (float)this.amountAlive))
            {
                Instantiate(this.bulletPrefab, enemy.position, Quaternion.identity);
                break;
            }
        }

    }

    private void Start()
    {
        InvokeRepeating(nameof(BulletAttack), this.bulletAttackRate, this.bulletAttackRate);
    }

    private void Update()
    {
        this.transform.position += _direction * this.speed.Evaluate(this.percentKilled) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach(Transform enemy in this.transform)
        {
            if(!enemy.gameObject.activeInHierarchy)
            {
                continue;
            }

            if(_direction == Vector3.right && enemy.position.x >= (rightEdge.x - 1.0f))
            {
                AdvanceRow();
            }
            else if(_direction == Vector3.left && enemy.position.x <= (leftEdge.x + 1.0f))
            {
                AdvanceRow();
            }
        }
    }

}
