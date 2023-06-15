using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GreenCheck : MonoBehaviour
{
    public GameObject greenCheck;
    // Start is called before the first frame update
    void Start()
    {
        greenCheck.SetActive(false);    
    }

    public IEnumerator ManageObject()
    {
        Debug.Log("Activam buton");
        greenCheck.SetActive(true);   
        yield return new WaitForSeconds(1f);
        greenCheck.SetActive(false);   
    }

}
