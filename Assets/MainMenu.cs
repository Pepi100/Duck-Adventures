using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;


public class MainMenu : MonoBehaviour
{
    void Start()
    {
        ScreenChanger.instance.SetLandscape();
    }
    
    public void PlayGame()
    {
        Debug.Log("am dat play");
        SaveSystem.LoadPlayer();
        PlayerData playerdata = PlayerData.instance;
        Debug.Log(playerdata.getIslandNumber());
        if(playerdata.getIslandNumber() == 1)
            SceneManager.LoadScene("First Island");
        else
            SceneManager.LoadScene("Second Island");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Setting Menu");
    }

    public void Save(GreenCheck obj)
    {
        Debug.Log("Saving");
        if(SaveSystem.SavePlayer() == 1){
            StartCoroutine(obj.ManageObject());
        }
    }

    public void ToAchievements()
    {
        Debug.Log("Achievements");
        SceneManager.LoadScene("Achievements");
    }

    public void ResetState(GreenCheck obj)
    {
        Debug.Log("Reset State");
        if(SaveSystem.DeletePlayer() == 1){
            StartCoroutine(obj.ManageObject());
        }
    }

    public void QuitGame()
    {
        Debug.Log("quit!");
        Application.Quit();
    }
}
