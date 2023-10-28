using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineProjectile : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5;
    private float startTime;
    private float lifeTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        rb.velocity = new Vector2(0, -speed);
        startTime = Time.time;
        transform.eulerAngles = new Vector3(0, 0, 270);
    }
    // Update is called once per frame
    void Update()
    {
        // Check if it's time to destroy the object
        if (Time.time - startTime > lifeTime)
        {
            Destroy(gameObject); // Destroy the GameObject
        }
    }
}
