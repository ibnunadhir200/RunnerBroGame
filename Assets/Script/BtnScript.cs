using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("RunGame");
    }
    public void ExitInGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

   public void QuitGame()
    {
        Application.Quit();
    }
}
