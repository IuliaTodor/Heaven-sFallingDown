using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Vector2 checkpointPos;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private PlayerMovement pm;
    [SerializeField] AnimationClip deathAnim;

    [SerializeField] private AudioSource deathSoundEffect;
    private enum MovementState
    {
        idle //Idle = 0. Walk = 1. gravity = 2. midAir = 3
    }

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

        checkpointPos = transform.position;

        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
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
        deathSoundEffect.Play();
               
        isAlive = false;
        rb.velocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Static;
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


        anim.SetInteger("state", (int)MovementState.idle);

        sr.enabled = true;
        anim.enabled = true;
        sr.flipY = false;
        rb.gravityScale = 3;

        transform.position = checkpointPos;

        anim.SetBool("isAlive", true);
        isAlive = true;
      
    }
}
