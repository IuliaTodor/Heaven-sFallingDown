using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnemyView : MonoBehaviour
{
    private GameObject enemy;
    private SpriteRenderer sr;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        sr = enemy.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            sr.flipX = true;
            Debug.Log("Entra");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sr.flipX = false;
            Debug.Log("Sale");
        }
    }
}
