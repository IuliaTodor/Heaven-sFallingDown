using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private PlayerLife playerLife;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    //Para cambiar el sprite según si has interactuado con el checkpoint
    public Sprite brown, golden;
    void Start()
    {
        playerLife = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLife>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider= GetComponent<BoxCollider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerLife.UpdateCheckpoint(transform.position);
            FindObjectOfType<AudioManager>().Play("Checkpoint");
            spriteRenderer.sprite = golden;
            boxCollider.enabled = false;
        }
    }
}
