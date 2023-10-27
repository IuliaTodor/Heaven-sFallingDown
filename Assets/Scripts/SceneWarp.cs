using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWarp : MonoBehaviour
{
    public Vector2 direction;
    public int pos;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Toca el trigger");
            Debug.Log(GameManager.instance.IsUnityNull());

            if (GameManager.instance != null)
            {
                Debug.Log("direction: " + direction);
                GameManager.instance.pos = pos;
                GameManager.instance.SceneChange(direction);
            }
        }
    }
}