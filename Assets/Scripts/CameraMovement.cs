using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;
    [SerializeField] private GameObject target;
    //C�mo de r�pido se mueve la c�mara hacia el jugador
    [SerializeField] private float speed;
    [SerializeField] private Vector2 maxPosition;
    [SerializeField] private Vector2 minPosition;
    // Start is called before the first frame update

    private void Awake()
    {
        // Ensure that there's only one instance of the camera
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject); // Destroy any duplicate instances
            return;
        }

        target = GameObject.FindWithTag("Player");

        //DontDestroyOnLoad(this.gameObject); // Keep this object when loading new scenes
    }
    void Start()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        }
    }

    // El jugador se mueve en Update, mientras que la c�mara se mueve en Late Update, para que vaya despu�s del movimiento del jugador.
    //De esta forma el movimiento del jugador va antes que el de la c�mara
    void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.transform.position)
            {
                Vector3 targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

                targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
                targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
                //Lerp (linear interpolation) calcula la distancia entre dos puntos y mueve el primer punto un porcentaje de esa distancia
                //cada frame hacia el segundo punto
                transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
            }
        }
    }
}
