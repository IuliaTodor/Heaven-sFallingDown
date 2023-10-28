using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimProjectile : MonoBehaviour
{
    private GameObject player;
    private PlayerLife playerLife;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5;
    private float startTime;
    private float lifeTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();

        Vector2 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        startTime = Time.time;
    }

    void Update()
    {
        // Check if it's time to destroy the object
        if (Time.time - startTime > lifeTime)
        {
            Destroy(gameObject); // Destroy the GameObject
        }
    }
}
