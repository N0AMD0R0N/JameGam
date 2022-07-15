using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        //SceneManager.LoadScene(1); // Probably going to need to change this
        Debug.Log("Game Started");
    }
    public void QuitGame()
    {
        Debug.Log("Game Quitted");
        Application.Quit();
    }
}
