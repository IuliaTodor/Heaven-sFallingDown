using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBarrier : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sr= GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(GameManager.instance.CDs >= 5)
        {
            bc.enabled= false;
            sr.enabled= false;
        }
    }
}
