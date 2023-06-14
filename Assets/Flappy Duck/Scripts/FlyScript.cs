using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlyScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float velocity = 1;
    public TextMeshProUGUI scoreText;
    public AudioSource audioSrc;

    private int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb.velocity = Vector2.up * velocity;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            //jump
            rb.velocity = Vector2.up * velocity;
            audioSrc.Play();


        }






    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ScoreTrigger"))
        {
            score++;
            scoreText.text = score.ToString();
        }

        Debug.Log(scoreText.text);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(score >= 20)
        {
            SceneManager.LoadScene("Win");
            
            if(score >= 30)
            {
                PlayerData.instance.Add(2);
            }
        }
        else
        {
            SceneManager.LoadScene("Lose2");
        }
        

    }
}
