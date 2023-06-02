using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DuckShoooter : MonoBehaviour
{
    public string sceneToLoad = "Shoot"; // the name of the scene to load when the character is clicked

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}


