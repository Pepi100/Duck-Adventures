using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class SettingsMenu : MonoBehaviour
{

    public void GoBack()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
