using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    //private int CDs = 0;

    [SerializeField] private TMP_Text CDsText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Collectable"))
        {
            FindObjectOfType<AudioManager>().Play("ItemCollect");
            Destroy(collision.gameObject);
            //collectSoundEffect.Play();
            GameManager.instance.CDs++;
            //CDs++;
            if (CDsText != null)
            {
                CDsText.text = "" + GameManager.instance.CDs;
            }
        }
    }
}
