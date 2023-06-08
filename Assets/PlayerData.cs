using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    #region Singleton
    public static PlayerData instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private bool[] achievementsIds = new bool[] { false, false, false, false, false, false, false };
    private int x, y;
    private bool[] gamesDone = new bool[] { false, false, false, false, false };
    private int islandNumber = 1;
    ///MUST ADD INVENTORY

    ///Call this method with the id of the achievement to mark as checked
    public void Add(int idAchiv)
    {
        if (!achievementsIds[idAchiv])
            achievementsIds[idAchiv] = true;
    }

    ///Deletes all the achievents. Useful for restart
    public void RemoveAllAchievemnts()
    {
        for (int i = 0; i <= 6; ++i) achievementsIds[i] = false;
    }

    ///Getter method
    public bool[] getAchievements()
    {
        return achievementsIds;
    }

    public bool[] getGamesDone()
    {
        return gamesDone;
    }
}
