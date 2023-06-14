using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string sceneToLoad; // the name of the scene to load when the character is clicked

    private void OnMouseDown()
    {
        if (sceneToLoad == "Second Island")
        {
            bool[] gamesDone = PlayerData.instance.getGamesDone();
            if (gamesDone[1] && gamesDone[2] && gamesDone[3])
                SceneManager.LoadScene(sceneToLoad);
            else
            {
                UnityEngine.Debug.Log("nu sunt jocurile gata");
            }
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
        }

    }
}

