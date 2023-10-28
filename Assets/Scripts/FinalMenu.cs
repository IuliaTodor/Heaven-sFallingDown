using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMenu : MonoBehaviour
{
    public GameObject finishMenu;

    public void Restart()
    {
        finishMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("0,0");
    }

    public void Menu()
    {
        finishMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
