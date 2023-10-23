using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    [SerializeField] float shootingRange = 5f;
    [SerializeField] float fireRate = 1f;
    [SerializeField] float nextFireTime;
    
    public GameObject projectile;
    public GameObject projectileParent;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;   
    }

    // Update is called once per frame
    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if(distanceFromPlayer < shootingRange && nextFireTime < Time.time)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, projectileParent.transform.position, Quaternion.identity);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, shootingRange);
    }

}
