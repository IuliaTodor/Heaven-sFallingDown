using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectilePosition;

    private float timer;
    [SerializeField] private float maxTime = 2;

    private GameObject player;
    private PlayerLife playerLife;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            timer = 0;

            //Así no dispara si el jugador está muriendo
            if(playerLife.GetIsPlayerAlive())
            {
                Shoot();
            }
          
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, projectilePosition.position, Quaternion.identity);
    }
}
