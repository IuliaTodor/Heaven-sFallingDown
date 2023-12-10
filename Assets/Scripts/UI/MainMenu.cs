using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        FindObjectOfType<AudioManager>().Play("StartGame");
        SceneManager.LoadSceneAsync("0,0");
        FindObjectOfType<AudioManager>().StopPlaying("MainMenu");
        FindObjectOfType<AudioManager>().Play("BackgroundMusic");
    }

    public void Credits()
    {
        FindObjectOfType<AudioManager>().Play("Credits");
    }

    public void CloseCredits()
    {
        FindObjectOfType<AudioManager>().Play("CloseCredits");
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("QuitGame");
        Application.Quit();
    }
}
