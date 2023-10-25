using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimProjectile : MonoBehaviour
{
    private GameObject player;
    private PlayerLife playerLife;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();

        Vector2 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerLife.Die();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
