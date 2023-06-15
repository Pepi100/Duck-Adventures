using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    public string sceneToLoad; // the name of the scene to load when the character is clicked
    public GameObject player;

    private void OnMouseDown()
    {
        if (sceneToLoad == "Second Island")
        {
            bool[] gamesDone = PlayerData.instance.getGamesDone();
            if (gamesDone[1] && gamesDone[2] && gamesDone[3]){
                PlayerData pd = PlayerData.instance;
                pd.setX(-12.5);
                pd.setY(-28.5);
                pd.setZ(0);
                pd.setIslandNumber(2);
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                UnityEngine.Debug.Log("nu sunt jocurile gata");
            }
        }
        else
        {
            PlayerData pd = PlayerData.instance;
            pd.setX(player.transform.position.x);
            pd.setY(player.transform.position.y);
            pd.setZ(player.transform.position.z);
            SceneManager.LoadScene(sceneToLoad);
        }

    }
}

