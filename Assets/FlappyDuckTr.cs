using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyDuckTr : MonoBehaviour
{
    public string sceneToLoad = "Menu"; // the name of the scene to load when the character is clicked

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

