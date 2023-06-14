using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData:MonoBehaviour
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

    private bool[] achievementsIds = new bool[]{false, false, false, false, false, false, false};
    private float x = 0, y = 0, z = 0;
    private bool[] gamesDone = new bool[]{false, false, false, false, false};
    private int islandNumber = 1; 

    ///Call this method with the id of the achievement to mark as checked

    public void DoneMinigame(int idMinigame)
    {
        gamesDone[idMinigame] = true;
    }

    public void Add(int idAchiv)
    {
        if (!achievementsIds[idAchiv])
            achievementsIds[idAchiv] = true;
    }

    ///Deletes all the achievents. Useful for restart
    public void ResetAll()
    {
        for(int i = 0; i <= 6; ++i)
            achievementsIds[i] = false;

        for(int i = 0; i <= 5; ++i)
            gamesDone[i] = false;

        x = 0; y = 0;
        ///sa salvam pozitia
        islandNumber = 1;
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

    public float getX(){
        return x;
    }

    public float getY(){
        return y;
    }

    public float getZ(){
        return z;
    }

    public int getIslandNumber(){
        return islandNumber;
    }

    public void setAchievements(bool[] newAchievementsIds)
    {
        achievementsIds = newAchievementsIds;
    }

    public void setX(double newX)
    {
        x = (float) newX;
    }

    public void setY(double newY)
    {
        y = (float) newY;
    }

    public void setZ(double newZ)
    {
        z = (float) newZ;
    }

    public void setGamesDone(bool[] newGamesDone)
    {
        gamesDone = newGamesDone;
    }

    public void setIslandNumber(int newIslandNumber)
    {
        islandNumber = newIslandNumber;
    }
    
}
