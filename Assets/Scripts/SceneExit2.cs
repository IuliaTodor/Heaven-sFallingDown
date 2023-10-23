using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit2 : MonoBehaviour
{
    [SerializeField] private string newScene;
    [SerializeField] private GameObject exitScene;
    [SerializeField] private GameObject enterScene;
    private GameObject player;

    //Igual que hasExitScene, pero con otro nombre para no confundir
    [SerializeField] public static bool goesBackToScene;
    private void Awake()
    {
 
        goesBackToScene = StateNameController.exitSceneBool;

        player = GameObject.FindGameObjectWithTag("Player");

        //if (goesBackToScene)
        //{
        //    Debug.Log(player.transform.position);
        //    Debug.Log(exitScene.transform.position);

        //    player.transform.position = new Vector3(exitScene.transform.position.x, exitScene.transform.position.y, exitScene.transform.position.z);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {
            SceneChange(newScene);
        }
    }

    private void SceneChange(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }


}
