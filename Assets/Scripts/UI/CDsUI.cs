using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDsUI : MonoBehaviour
{
    public static CDsUI instance;
    public GameObject CDUI;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
            return;
        }
       
    }

    private void Update()
    {
        if(PauseMenu.GameIsPaused)
        {
            CDUI.SetActive(false);
        }

        else
        {
            CDUI.SetActive(true);
        }
    }
}
