using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Vector2 sceneChangeVector;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }       
        else
        {
            Debug.Log("Más de un gm en escena");
        }
     }

    private void Start()
    {
        //La escena a la que queremos ir
        sceneChangeVector = new Vector2();
    }

    public void SceneChange(Vector2 dir)
    {   string currentSceneName = SceneManager.GetActiveScene().name.ToString();
        Debug.Log("CurrentSceneName: " + currentSceneName);
        string sceneTo = currentSceneName.ToString();
        Debug.Log("SceneTo: " + sceneTo);
        string[] sceneToparts = sceneTo.Split(',');
        Debug.Log("sceneToParts: " + sceneToparts);

        float sceneToXCoordinate = float.Parse(sceneToparts[0]);
        Debug.Log("sceneToXCoordinate: " + sceneToXCoordinate);
        float sceneToYCoordinate = float.Parse(sceneToparts[1]);
        Debug.Log("sceneToYCoordinate: " + sceneToYCoordinate);

        sceneChangeVector = new Vector2(sceneToXCoordinate, sceneToYCoordinate);
        Debug.Log("sceneChangeVector: " + sceneChangeVector);
        
        Vector2 newSceneVector = new Vector2(sceneChangeVector.x + dir.x, sceneChangeVector.y + dir.y);
        Debug.Log("newSceneVector: " + newSceneVector);
        string str = "" + Mathf.Round(newSceneVector.x) + "," + Mathf.Round(newSceneVector.y);
        Debug.Log("str: " + str);
        SceneManager.LoadScene(str);
    }
}