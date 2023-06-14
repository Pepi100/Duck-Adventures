using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class DTOPlayerData
{
    private bool[] achievementsIds;
    private float x, y, z;
    private bool[] gamesDone;
    private int islandNumber;
    private bool firstTimeDuckShooter;

    public DTOPlayerData ()
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
        player.setAchievements(achievementsIds);
        if(player.getX() == 0 && player.getY() == 0 && player.getZ() == 0){
            player.setX(x);
            player.setY(y);
            player.setZ(z);
            player.setIslandNumber(islandNumber);
        }
        player.setGamesDone(gamesDone);
        player.setIslandNumber(islandNumber);
        player.setFTDS(firstTimeDuckShooter);
    }

    
}
