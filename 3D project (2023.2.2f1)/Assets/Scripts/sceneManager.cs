using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneManager : MonoBehaviour
{
   public void changeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Restart()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(PlayerPrefs.GetInt("UnlockedLevel"));
    }
    public void quitApplication()
    {
        Application.Quit();
    }

    public void Next()
    {
        if (PlayerPrefs.GetInt("UnlockedLevel") <= 5)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("UnlockedLevel") + 1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }


}
