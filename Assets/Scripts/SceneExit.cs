using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    [SerializeField] private string newScene;
    [SerializeField] private GameObject exitScene;
    [SerializeField] private GameObject enterScene;
    [SerializeField] private float distanceFromObjectX;
    [SerializeField] private float distanceFromObjectY;
    private float exitSceneWidth;
    private float exitSceneHeight;
    //[SerializeField] private Vector2 playerPosition;
    //[SerializeField] private VectorAppear playerStorage;


    private void Awake()
    {
        Collider2D enterSceneCollider = enterScene.GetComponent<Collider2D>();
        exitSceneWidth = enterSceneCollider.bounds.size.x * distanceFromObjectX;
        exitSceneHeight = enterSceneCollider.bounds.size.y * distanceFromObjectY;
    }

    private void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger)
        {

            SceneChange(newScene);

            if (enterScene.CompareTag("EnterScene"))
            {
                Debug.Log(SceneManager.GetActiveScene().buildIndex); 

                SetPlayerPosition();
            }
        }
    }

    private void SetPlayerPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Set the player's position to the enterScene position
        player.transform.position = new Vector3(enterScene.transform.position.x, enterScene.transform.position.y, enterScene.transform.position.z);

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
