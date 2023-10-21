using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEnter2 : MonoBehaviour
{
    [SerializeField] private string newScene;
    [SerializeField] private GameObject enterScene;
    [SerializeField] private GameObject exitScene;
    private GameObject player;
    //Calcula si has salido de la escena
    private bool hasExitScene;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //Si estás spawneando en la escena empiezas en el punto inicial
        if (hasExitScene == false)
        {
            player.transform.position = new Vector3(enterScene.transform.position.x + 4, enterScene.transform.position.y, enterScene.transform.position.z);
        }

        hasExitScene = StateNameController.exitSceneBool;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter");
        //La idea es que en el primer nivel esto es false. Si llegas al segundo nivel y vuelves al primero esto se vuelve true
        hasExitScene = true;
        //Esto está en un script estático donde este bool es lo único que hay. Sirve para moverse entre los dos scripts de escenas
        //y no dar problemas
        StateNameController.exitSceneBool = true;

        if(collision.CompareTag("Player") && !collision.isTrigger) {
            
            SceneChange(newScene);
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("Trigger Stay");

    //    if (collision.CompareTag("Player") && !collision.isTrigger)
    //    {

    //        player.transform.position = new Vector3(exitScene.transform.position.x, exitScene.transform.position.y, exitScene.transform.position.z);

    //    }
    //}

    private void SceneChange(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }
}
