using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private int CDs = 0;

    [SerializeField] private TMP_Text CDsText;

    [SerializeField] private AudioSource collectSoundEffect;

    //Usamos este m�todo porque pusimos su BoxCollider en IsTrigger. De esta forma el jugador pasar� a trav�s
    //del objeto para cogerlo. Si no hubiesemos puesto eso hubiesemos tenido que usar el m�todo
    //OnCollisionEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectable"))
        {
           
            Destroy(collision.gameObject);
            collectSoundEffect.Play();
            CDs++;
            CDsText.text = "" + CDs;
        }
    }
}
