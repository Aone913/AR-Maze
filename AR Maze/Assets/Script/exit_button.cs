using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit_button : MonoBehaviour
{
    public void exitApps()
    {
        Debug.Log("application already exit");
        Application.Quit();
    }
}