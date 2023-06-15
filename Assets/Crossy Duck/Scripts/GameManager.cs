using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Demo duck;
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
        duck = FindObjectOfType<Demo>();
        ScreenChanger.instance.SetPortrait();
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
        if(lives - 1 < 0){
            SetLives(0);
        }
        else
        {
            SetLives(lives - 1);
        }

        if(lives > 0)
        {
            Invoke(nameof(Respawn), 0.01f);
        }
        else 
        {
            Invoke(nameof(GameOver), 0.01f);
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

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                playAgain = true;
            }
            // if(Input.GetKeyDown(KeyCode.Return))
            // {
            //     playAgain = true;
            // }

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
            if (score > 500)
            {
                PlayerData.instance.Add(3);
            }
            if (lives >= 5)
            {
                PlayerData.instance.Add(4);
            }
            PlayerData.instance.DoneMinigame(3);
            SceneManager.LoadScene("Win");
        }
        else 
        {
            Invoke(nameof(Respawn), 0.01f);
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
