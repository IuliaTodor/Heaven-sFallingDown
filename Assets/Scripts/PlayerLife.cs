using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool isAlive = true;

    public bool GetIsPlayerAlive()
    {
        return isAlive;
    }

    [SerializeField] private AudioSource deathSoundEffect;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Daño"))
        {
            Die();
        }
    }



    private void Die()
    {
        deathSoundEffect.Play();
        //De esta forma el jugador no se podrá mover tras morir
        rb.bodyType = RigidbodyType2D.Static;
        isAlive = false;
        anim.SetTrigger("death");
       
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
