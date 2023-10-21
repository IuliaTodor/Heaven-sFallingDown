using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEnter3 : MonoBehaviour
{
    [SerializeField] private string newScene;
    [SerializeField] private GameObject enterScene;
    [SerializeField] private GameObject exitScene;
    private GameObject player;
    private bool hasExitScene;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = new Vector3(enterScene.transform.position.x + 4, enterScene.transform.position.y, enterScene.transform.position.z);

        hasExitScene = StateNameController.exitSceneBool;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Enter");

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
