using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        Debug.Log("am dat play");
        SceneManager.LoadScene("First Island");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Setting Menu");
    }
    public void QuitGame()
    {
        Debug.Log("quit!");
        Application.Quit();
    }
}
