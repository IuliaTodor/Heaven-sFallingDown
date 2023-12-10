using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TMP_Text CDsText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {

            FindObjectOfType<AudioManager>().Play("ItemCollect");
            Destroy(collision.gameObject);

            GameManager.instance.CDs++;

            if (CDsText != null)
            {
                CDsText.text = "" + GameManager.instance.CDs;
            }

        }

    }
}
