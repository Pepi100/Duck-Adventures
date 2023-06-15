using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
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

    
    private float x = 0, y = 0, z = 0;
    
    private int islandNumber = 1; 
    private bool[] achievementsIds = new bool[] { false, false, false, false, false, false, false };
                                                    //1=pingpong, 2=flappy, 3=crossy1, 4=crossy2, 5=duckshooter, 6=all
    
    private bool[] gamesDone = new bool[] { false, false , false, false, false };
                                                //1= Flappy, 2=PingPong, 3=Crossy, 4=Shooter
  
    private bool firstTryDuckShooter = false;


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

    public void Remove(int idAchiv)
    {
        achievementsIds[idAchiv] = false;
    }

    ///Deletes all the achievents. Useful for restart
    public void ResetAll()
    {
        for(int i = 0; i <= 6; ++i)
            achievementsIds[i] = false;

        for(int i = 0; i <= 4; ++i)
            gamesDone[i] = false;

        x = 0; y = 0; z = 0;
        ///sa salvam pozitia
        islandNumber = 1;
        firstTryDuckShooter = false;
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

    public bool getFTDS()
    {
        return firstTryDuckShooter;
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
    public void setFTDS(bool status)
    {
        firstTryDuckShooter = status;
    }
}
