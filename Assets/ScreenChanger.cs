using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChanger : MonoBehaviour
{
    #region Singleton
    public static ScreenChanger instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    #endregion

    
    public void SetLandscape()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    public void SetPortrait()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
