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

    [SerializeField] private AudioSource deathSoundEffect;

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

        //playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>(); 
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
        //De esta forma el jugador no se podrá mover tras morir
        //rb.bodyType = RigidbodyType2D.Static;
       
        isAlive = false;
        anim.SetTrigger("death");
      
        StartCoroutine(Respawn(2f));
    }



    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);

        anim.enabled = false;
        sr.enabled = false;

        yield return new WaitForSeconds(2f); 

        sr.enabled = true;
        anim.enabled = true;

        transform.position = checkpointPos;

        isAlive = true;



    }
}
