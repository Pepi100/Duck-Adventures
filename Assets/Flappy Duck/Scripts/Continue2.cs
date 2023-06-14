using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continue2 : MonoBehaviour
{
    public void LoadGame()
    {
        Debug.Log("Dap");
        SceneManager.LoadScene("First Island");
    }
}
