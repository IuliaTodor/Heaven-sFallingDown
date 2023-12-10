using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Vector2 checkpointPos;
    //private Vector2 defaultRespawnPos;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    [SerializeField] AnimationClip deathAnim;

    private bool isAlive = true;

    public bool GetIsPlayerAlive()
    {
        return isAlive;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();


        checkpointPos = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Daño"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Daño"))
        {
            Die();
        }
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    public void Die()
    {
        FindObjectOfType<AudioManager>().Play("Die");

        isAlive = false;
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
        bc.enabled = false;

        anim.SetBool("isAlive", false);
        anim.SetTrigger("death");

        StartCoroutine(Respawn(1.5f));
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(deathAnim.length);

        anim.enabled = false;
        sr.enabled = false;

        yield return new WaitForSeconds(duration);

        rb.bodyType = RigidbodyType2D.Dynamic;

        Vector2 respawnPosition;

        if (checkpointPos != Vector2.zero)
        {
            respawnPosition = checkpointPos;
        }
        else
        {
            respawnPosition = GameManager.instance.defaultRespawnPos;
        }

        transform.position = respawnPosition;

        sr.enabled = true;
        anim.enabled = true;
        bc.enabled = true;
        sr.flipY = false;
        rb.gravityScale = 3;

        transform.position = checkpointPos;

        anim.SetBool("isAlive", true);
        isAlive = true;

    }
}
