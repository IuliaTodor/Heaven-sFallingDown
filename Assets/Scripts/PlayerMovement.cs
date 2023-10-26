using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    private PlayerLife playerLife;

    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] private float gravity = 3f;
    [SerializeField] public bool isFlippedY;
    [SerializeField] public bool isFlippedX;
    [SerializeField] private AudioSource gravitySoundEffect;
    public static PlayerMovement instance;

    private float directionX = 0f;
    private bool grounded;
    private enum MovementState
    {
        idle, walk, gravity, midAir //Idle = 0. Walk = 1. gravity = 2. midAir = 3
    }

    private void Awake()
    {
        //Singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerLife = GetComponent<PlayerLife>();

        rb.gravityScale = gravity;
        spriteRenderer.flipY = isFlippedY;
        grounded = false;
    }

    private void Update()
    {
        if (playerLife.GetIsPlayerAlive())
        {
            //Cuando vayamos a la izquierda será -1, cuando vayamos a la derecha será 1
            //GetAxis vuelve a 0 gradualmente, GetAxisRaw vuelve a 0 inmediatamente
            //Solo creamos esta variable aquí porque no la necesitamos en otro sitio que no sea update
            directionX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(directionX * moveSpeed, rb.velocity.y);
        }

        //Para que el jugador no pueda girar al morir
        else
        {
            directionX = 0f;
        }

        //Permite cambiar la gravedad si pulsas el botón de salto y estás tocando el suelo
        if (Input.GetButtonDown("Jump") && grounded)
        {

            rb.gravityScale *= -1f;
            spriteRenderer.flipY = !spriteRenderer.flipY;
            gravitySoundEffect.Play();

        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {

        MovementState state;

        if (directionX > 0f)
        {
            state = MovementState.walk;
            spriteRenderer.flipX = false;
        }

        else if (directionX < 0f)
        {
            state = MovementState.walk;
            spriteRenderer.flipX = true;
        }

        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f || rb.velocity.y < -.1f)
        {
            if (grounded)
            {
                state = MovementState.gravity;
            }

            else
            {
                state = MovementState.midAir;
            }
        }

        anim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = false;
        }
    }
}
