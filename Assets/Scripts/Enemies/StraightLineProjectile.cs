using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5;
    private float startTime;
    private float lifeTime = 3;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(0, -speed);
        startTime = Time.time;
        transform.eulerAngles = new Vector3(0, 0, 270);
    }
    void Update()
    {
        if (Time.time - startTime > lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
