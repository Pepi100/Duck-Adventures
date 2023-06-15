using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class DOTPlayerData
{
    private bool[] achievementsIds;
    private float x, y, z;
    private bool[] gamesDone;
    private int islandNumber;
    private bool firstTimeDuckShooter;

    public DOTPlayerData ()
    {
        PlayerData player = PlayerData.instance;
        achievementsIds = player.getAchievements();
        x = player.getX();
        y = player.getY();
        z = player.getZ();
        gamesDone = player.getGamesDone();
        islandNumber = player.getIslandNumber();
        firstTimeDuckShooter = player.getFTDS();
    }

    public void createSingleton()
    {
        PlayerData player = PlayerData.instance;
        if(player.getX() == 0 && player.getY() == 0 && player.getZ() == 0){
            player.setX(x);
            player.setY(y);
            player.setZ(z);
            player.setIslandNumber(islandNumber);
            player.setAchievements(achievementsIds);
            player.setGamesDone(gamesDone);
            player.setIslandNumber(islandNumber);
            player.setFTDS(firstTimeDuckShooter);
        }
        
    }

    
}
