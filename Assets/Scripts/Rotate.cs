using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    //Cuantas veces rotamos el objeto 360º por segundo
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        //transform.Rotate(float XAngle, float YAngle, float ZAngle)
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
