using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadSceneAsync("0,0");
        FindObjectOfType<AudioManager>().StopPlaying("MainMenu");
        FindObjectOfType<AudioManager>().Play("BackgroundMusic");
    }

    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("MenuClick");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
