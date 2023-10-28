using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBarrier : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        sr= GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //La barrera desaparece si el jugador tiene los CDs necesarios
        if(GameManager.instance.CDs >= 5)
        {
            bc.enabled= false;
            sr.enabled= false;
        }
    }
}
