using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        //Screen.autorotateToPortrait = true;
        //Screen.autorotateToLandscapeRight = false;
        //Screen.orientation = ScreenOrientation.AutoRotation;
    }
    
    // Update is called once per frame
    void Update () {
    
    }
}
