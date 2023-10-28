using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneWarp : MonoBehaviour
{
    public Vector2 direction;
    public int pos;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.pos = pos;
                GameManager.instance.SceneChange(direction);
            }
        }
    }
}