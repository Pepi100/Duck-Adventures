using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicGoToScene : MonoBehaviour
{
    public string sceneToLoad;
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
