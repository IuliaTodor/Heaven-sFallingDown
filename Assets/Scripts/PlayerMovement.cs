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
    private BoxCollider2D collision;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    public float directionX = 0f;
    [SerializeField] public float moveSpeed = 7f;
    [SerializeField] private float gravity = 3f;
    [SerializeField] private bool isFlippedY;
    public static PlayerMovement instance;

    private bool grounded;
    private enum MovementState
    {
        idle, walk, gravity, midAir //Idle = 0. Walk = 1. gravity = 2. midAir = 3
    }

    [SerializeField] private AudioSource gravitySoundEffect;

    private PlayerLife playerLife;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("Instance set to this");
        }
        else
        {
            if (instance != this)
            {
                Debug.Log("Instance already exists, destroying this GameObject.");
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = gravity;
        playerLife = GetComponent<PlayerLife>();

        spriteRenderer.flipY = isFlippedY;
        grounded = false;

        //transform.position = startingPosition.initialValue;



    }

    // Update is called once per frame
    private void Update()
    {
        if (playerLife.GetIsPlayerAlive())
        {
            //Lo ponemos en Update porque queremos hacer la acción a lo largo del juego y no solo al inicio

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

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
    }

    //private bool IsGrounded()
    //{
    //    //Crea una caja alrededor del jugador del mismo tamaño que su Box Collider. Esto se establece con los
    //    //dos primeros argumentos, que son bounds.center y bounds.size. 0f es la rotación.

    //    //Lo que hacen Vector2.down y 1f es mover la caja ligeramente hacia abajo. Así podemos comprobar si hay
    //    //algo interactuando con esa caja. Así podemos saber si estamos tocando el suelo

    //    //JumpableGround es una capa que hemos creado para el tileset del suelo/techo. Es el suelo con el que se
    //    //comprueba si estamos interactuando
    //    //return Physics2D.BoxCast(collision.bounds.center, collision.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    //}
}
