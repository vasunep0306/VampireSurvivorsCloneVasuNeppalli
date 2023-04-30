using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void QuitApplication()
    {
        Debug.Log("Application quit!");
        Application.Quit();
    }
}
