using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEnter : MonoBehaviour
{
    [SerializeField] private string newScene;
    [SerializeField] private GameObject exitScene;
    [SerializeField] private GameObject enterScene;
    //[SerializeField] private float distanceFromObjectX;
    //[SerializeField] private float distanceFromObjectY;
    //private float enterSceneWidth = 0;
    //private float enterSceneHeight = 0;
    //[SerializeField] private Vector2 playerPosition;
    //[SerializeField] private VectorAppear playerStorage;


    private void Awake()
    {
        Collider2D enterSceneCollider = enterScene.GetComponent<Collider2D>();
        SetPlayerPosition();
        //enterSceneWidth = enterSceneCollider.bounds.size.x;
        //enterSceneHeight = enterSceneCollider.bounds.size.y * distanceFromObjectY;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Set the player's position to the enterScene position
        Debug.Log("Entra al enter");
        player.transform.position = new Vector3(exitScene.transform.position.x, exitScene.transform.position.y, exitScene.transform.position.z);
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





    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    //if (collision.CompareTag("Player") && !collision.isTrigger)
    //    //{
    //    //    //playerStorage.initialValue = playerPosition;
    //    //    SceneChange(newScene);
    //    //}
    //}

    //private void SceneChange(string newScene)
    //{
    //    SceneManager.LoadScene(newScene);
    //}
}
