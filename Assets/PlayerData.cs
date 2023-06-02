using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    #region Singleton
    public static PlayerData instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
                    
            /*TO DO salvat datele*/
            for(int i = 1; i <= 6; ++i)
                achievementsIds.Add(i, false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    private Dictionary<int, bool> achievementsIds = new Dictionary<int, bool>();
    ///MUST ADD INVENTORY

    ///Call this method with the id of the achievement to mark as checked
    public void Add(int idAchiv)
    {
        if(!achievementsIds[idAchiv])
            achievementsIds[idAchiv] = true;
    }

    ///Deletes all the achievents. Useful for restart
    public void RemoveAllAchievemnts()
    {
        for(int i = 1; i <= 6; ++i)
            achievementsIds[i] = false;
    }

    ///Getter method
    public Dictionary<int, bool> getAchievements(){
        return achievementsIds;
    }
}
