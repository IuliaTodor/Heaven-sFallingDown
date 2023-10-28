using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Vector2 checkpointPos;
    private Vector2 defaultRespawnPos;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private PlayerMovement pm;
    private GameObject spawnPoint;
    [SerializeField] AnimationClip deathAnim;

    private bool isAlive = true;

    private GameObject[] enemies;
    public bool GetIsPlayerAlive()
    {
        return isAlive;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        checkpointPos = transform.position;

        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        enemies = GameObject.FindGameObjectsWithTag("Daño");

        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        if (spawnPoint != null)
        {
            defaultRespawnPos = spawnPoint.transform.position; 
        }
        else
        {
            Debug.LogError("SpawnPoint not found!");
            defaultRespawnPos = transform.position;
        }
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
        anim.SetBool("isAlive", false);
        anim.SetTrigger("death");

        //Para que el collider de los enemigos desaparezca y así no pueda haber dos enemigos atacando a la vez al jugador
        foreach (GameObject enemy in enemies)
        {
            BoxCollider2D enemyBoxCollider = enemy.GetComponent<BoxCollider2D>();
            enemyBoxCollider.enabled = false;
        }

        StartCoroutine(Respawn(1.5f));
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(deathAnim.length);

        anim.enabled = false;
        sr.enabled = false;

        yield return new WaitForSeconds(duration);

        rb.bodyType = RigidbodyType2D.Dynamic;

        foreach (GameObject enemy in enemies)
        {
            BoxCollider2D enemyBoxCollider = enemy.GetComponent<BoxCollider2D>();
            enemyBoxCollider.enabled = true;
        }

        Vector2 respawnPosition;

        if (checkpointPos != Vector2.zero)
        {
            respawnPosition = checkpointPos;
        }
        else
        {
            respawnPosition = defaultRespawnPos;
        }

        transform.position = respawnPosition;

        sr.enabled = true;
        anim.enabled = true;
        sr.flipY = false;
        rb.gravityScale = 3;

        transform.position = checkpointPos;

        anim.SetBool("isAlive", true);
        isAlive = true;

    }
}
