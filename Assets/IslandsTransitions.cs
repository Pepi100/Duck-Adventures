using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslandsTransitions : MonoBehaviour
{
    public string sceneToLoad = "Second Island"; // the name of the scene to load when the character is clicked

    private void OnMouseDown()
    {

        bool[] gamesDone = PlayerData.instance.getGamesDone();
        if(gamesDone[1] && gamesDone[2] && gamesDone[3])
            SceneManager.LoadScene(sceneToLoad);
        else{
            Debug.Log("nu sunt jocurile gata");
        }
    }
}

