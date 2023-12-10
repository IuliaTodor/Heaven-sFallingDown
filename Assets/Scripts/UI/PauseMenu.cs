using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public static PauseMenu instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                FindObjectOfType<AudioManager>().Play("ClosePauseMenu");
            }

            else
            {
                Pause();
             
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<AudioManager>().Play("ClosePauseMenu");
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        FindObjectOfType<AudioManager>().Play("OpenPauseMenu");
    }

    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("QuitGame");
        Application.Quit();
    }
}
