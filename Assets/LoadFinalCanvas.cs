using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFinalCanvas : MonoBehaviour
{
    [SerializeField] public GameObject finishMenu;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
             FindObjectOfType<AudioManager>().StopPlaying("BackgroundMusic");
            FindObjectOfType<AudioManager>().Play("FinalSong");
            Time.timeScale = 0f;
            finishMenu.SetActive(true);
           
        }

    }
}
