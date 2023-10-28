using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 3f;

    private void Update()
    {
       
        //Vector2.Distance: Devuelve la distancia entre a y b
        //Vector2.Distance(Vector2 a, Vector2 b)
        //Si la posición del waypoint al que queremos ir y la posición del objeto es menor a 0.1
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            //El waypoint al que queremos ir cambia
            currentWaypointIndex++;

            //Solo aplica si hay dos waypoints. Cuando llega al waypoint de índice más grande el objeto
            //vuelve a su origen (el waypoint[0])
            if(currentWaypointIndex >= (waypoints.Length))
            {
                currentWaypointIndex = 0;
            }
        }

        //Vector2.MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta)
        //En este caso la posición del gameObject va hacia la posición del waypoint designado recorriendo la velocidad que hemos designado
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        //Time.deltaTime * speed: Se mueve ciertas unidades por frame sin importar el frameRate (esto es gracias al DeltaTime)
    }
}
