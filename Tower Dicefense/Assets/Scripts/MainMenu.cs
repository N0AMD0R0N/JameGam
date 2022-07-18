using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Defeatable;
    public GameObject GameOverText;
    public void Start()
    {
        GameOverText.gameObject.SetActive(false);
        Defeatable.GetComponent<IDefeatable>().onDefeat(gameOver);
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("MainScene");
            Time.timeScale = 1;
        }
    }
    
    public void gameOver() {
        Time.timeScale = 0;
        GameOverText.gameObject.SetActive(true);
    }
}
