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

    
    public void GoBackAndSave(GameObject player)
    {
        PlayerData pd = PlayerData.instance;
        pd.setX(player.transform.position.x);
        pd.setY(player.transform.position.y);
        pd.setZ(player.transform.position.z);
        SceneManager.LoadScene("Main Menu");
    }
}
