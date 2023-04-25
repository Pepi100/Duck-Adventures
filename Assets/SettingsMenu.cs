using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public float volumevalue;

    void Start()
    {
        audioMixer = PlayerPrefs.GetFloat("Volume");
    }
    void Update()
    {
        audioMixer.SetFloat("Volume", volumevalue);
        PlayerPrefs.SetFloat("Volume", volumevalue);
        PlayerPrefs.Save();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void GoBack()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
