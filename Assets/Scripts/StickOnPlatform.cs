using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//No llego a usar este script. Era para plataformas que se mov�an que no us� al final. Lo he dejado por si acaso
public class StickOnPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Entra al Exit");
            collision.gameObject.transform.SetParent(null);
        }
    }
}
