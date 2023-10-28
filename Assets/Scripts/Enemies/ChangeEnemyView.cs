using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gira al enemigo que dispara según si el jugador se pone detrás suyo
public class ChangeEnemyView : MonoBehaviour
{
    private GameObject enemy;
    private SpriteRenderer sr;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        sr = enemy.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            sr.flipX = true;
        }   
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sr.flipX = false;
        }
    }
}
