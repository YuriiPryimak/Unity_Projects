using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
        //Application.Quit();   
    }
}
