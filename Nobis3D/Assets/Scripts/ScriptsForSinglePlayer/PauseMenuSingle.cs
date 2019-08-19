using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuSingle : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    private void Awake()
    {
        pauseMenuUI.SetActive(false); //активация паузы
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        } 
        else if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); //активация паузы
        Time.timeScale = 1f;         //заморозка времени
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); //активация паузы
        Time.timeScale = 0f;         //заморозка времени
        GameIsPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene("SinglePlayer");
        //GameIsPaused = false;
        //Time.timeScale = 1f;
        //NewEnemyController cont = new NewEnemyController();
        //cont.checkOfDying = 0;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
