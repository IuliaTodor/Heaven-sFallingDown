using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject waypoint1;
    public GameObject waypoint2;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = waypoint2.transform;
        anim.SetBool("IsRunning", true);
    }
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == waypoint2.transform) {
            rb.velocity = new Vector2(speed, 0);
        }

        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == waypoint2.transform)
        {
            currentPoint = waypoint1.transform;
            Flip();
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == waypoint1.transform)
        {
            currentPoint = waypoint2.transform;
            Flip();
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
