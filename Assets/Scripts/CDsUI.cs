using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDsUI : MonoBehaviour
{
    public static CDsUI instance;
    public GameObject CDUI;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
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
