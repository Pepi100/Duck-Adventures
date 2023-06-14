using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        Debug.Log("am dat play");
        SaveSystem.LoadPlayer();
        PlayerData playerdata = PlayerData.instance;
        if(playerdata.getIslandNumber() == 1)
            SceneManager.LoadScene("First Island");
        else
            SceneManager.LoadScene("Second Island");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Setting Menu");
    }

    public void Save()
    {
        Debug.Log("Saving");
        SaveSystem.SavePlayer();
    }

    public void ToAchievements()
    {
        Debug.Log("Achievements");
        SceneManager.LoadScene("Achievements");
    }

    public void QuitGame()
    {
        Debug.Log("quit!");
        Application.Quit();
    }
}
