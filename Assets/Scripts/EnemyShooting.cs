using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] Transform projectilePosition;

    private float timer;
    private float maxTime = 1;

    private GameObject player;
    private PlayerLife playerLife;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerLife = player.GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTime)
        {
            timer = 0;
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
