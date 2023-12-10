using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector2 sceneChangeVector;
    public static GameManager instance;
    public int CDs;
    public int pos;

    public GameObject spawnPoint;
    public Vector2 defaultRespawnPos;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }       
     }

    private void Start()
    {
        //La escena a la que queremos ir
        sceneChangeVector = new Vector2();
    }

    public void SceneChange(Vector2 dir)
    {   string currentSceneName = SceneManager.GetActiveScene().name.ToString();
        string sceneTo = currentSceneName.ToString();
        string[] sceneToparts = sceneTo.Split(',');
        
        float sceneToXCoordinate = float.Parse(sceneToparts[0]);
        float sceneToYCoordinate = float.Parse(sceneToparts[1]);

        sceneChangeVector = new Vector2(sceneToXCoordinate, sceneToYCoordinate);
        
        Vector2 newSceneVector = new Vector2(sceneChangeVector.x + dir.x, sceneChangeVector.y + dir.y);
        string str = "" + Mathf.Round(newSceneVector.x) + "," + Mathf.Round(newSceneVector.y);

        //Activa esto tras cargar la siguiente escena
        SceneManager.sceneLoaded += OnSceneLoaded;

        SceneManager.LoadScene(str);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Así no se activa múltiples veces
        SceneManager.sceneLoaded -= OnSceneLoaded;

        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPointL");

        if (spawnPoint != null)
        {
            defaultRespawnPos = spawnPoint.transform.position;
        }
        else
        {
            defaultRespawnPos = transform.position;
        }
    }
}