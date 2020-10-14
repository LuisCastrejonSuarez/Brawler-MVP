using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenManager : MonoBehaviour
{
    public void GoToScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
