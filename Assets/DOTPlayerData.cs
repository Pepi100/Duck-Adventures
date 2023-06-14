using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class DOTPlayerData
{
    private bool[] achievementsIds;
    private int x, y;
    private bool[] gamesDone;
    private int islandNumber;
    private bool firstTimeDuckShooter;

    public DOTPlayerData ()
    {
        PlayerData player = PlayerData.instance;
        achievementsIds = player.getAchievements();
        x = player.getX();
        y = player.getY();
        gamesDone = player.getGamesDone();
        islandNumber = player.getIslandNumber();
        firstTimeDuckShooter = player.getFTDS();
    }

    public void createSingleton()
    {
        PlayerData player = PlayerData.instance;
        player.setAchievements(achievementsIds);
        player.setX(x);
        player.setY(y);
        player.setGamesDone(gamesDone);
        player.setIslandNumber(islandNumber);
        player.setFTDS(firstTimeDuckShooter);
    }

    
}
