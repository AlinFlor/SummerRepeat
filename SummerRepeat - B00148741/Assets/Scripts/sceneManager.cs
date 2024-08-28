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
    public void quitApplication()
    {
        Application.Quit();
    }


}
