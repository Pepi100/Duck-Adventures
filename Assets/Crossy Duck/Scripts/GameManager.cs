using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Duck duck;
    private Home[] homes;

    public GameObject gameOverMenu;
    
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public TMP_Text timeText;

    private int score;
    private int lives;
    private int time;

    private void Awake()
    {
        homes = FindObjectsOfType<Home>();
        duck = FindObjectOfType<Duck>();
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        gameOverMenu.SetActive(false);

        SetScore(0);
        SetLives(3);
        NewLevel();
    }

    private void NewLevel()
    {
        for(int i = 0; i < homes.Length; i++)
        {
            homes[i].enabled = false;
        }
        Respawn();
    }

    private void Respawn()
    {
        duck.Respawn();

        StopAllCoroutines();
        StartCoroutine(Timer(30));
    }

    private IEnumerator Timer(int duration)
    {
        time = duration;
        timeText.text = time.ToString();
        
        while(time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            timeText.text = time.ToString();
        }

        duck.Death();
    }

    public void Died()
    {
        SetLives(lives - 1);

        if(lives > 0)
        {
            Invoke(nameof(Respawn), 1f);
        }
        else 
        {
            Invoke(nameof(GameOver), 1f);
        }
    }

    private void GameOver()
    {
        duck.gameObject.SetActive(false);
        gameOverMenu.SetActive(true);

        StopAllCoroutines();
        StartCoroutine(PlayAgain());
    }

    private IEnumerator PlayAgain()
    {
        bool playAgain = false; 

        while(!playAgain)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                playAgain = true;
            }

            yield return null;
        }

        NewGame();
    }

    public void HomeOccupied()
    {
        duck.gameObject.SetActive(false);

        int bonusPoints = time * 20;
        SetScore(score + 50 + bonusPoints);

        if(Cleared())
        {
            SetScore(score + 1000);
            SetLives(lives + 1);
            Invoke(nameof(NewLevel), 1f);
            SceneManager.LoadScene("Win3");
        }
        else 
        {
            Invoke(nameof(Respawn), 1f);
        }
    }

    private bool Cleared()
    {
        for(int i = 0; i < homes.Length; i++)
        {
            if(!homes[i].enabled)
            {
                return false;
            }
        }
        return true;
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = lives.ToString();
    }
}
