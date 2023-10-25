using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineProjectile : MonoBehaviour
{
    private GameObject player;
    private PlayerLife playerLife;
    private Rigidbody2D rb;
    [SerializeField] private GameObject waypoint; // Reference to your waypoint GameObject
    [SerializeField] private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();
        // Replace "Waypoint" with your waypoint's name in the scene

        Vector2 direction = waypoint.transform.position - transform.position;
        rb.velocity = direction.normalized * speed;

        //Vector2 direction = player.transform.position - transform.position;
        //rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerLife.Die();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
