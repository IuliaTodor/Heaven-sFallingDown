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

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }       
        else
        {
            Debug.Log("M�s de un gm en escena");
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
        SceneManager.LoadScene(str);
    }
}