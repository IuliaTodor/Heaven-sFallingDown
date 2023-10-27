using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public int pos;
    private GameObject player;

    private void Awake()
    {
        if(GameManager.instance.pos == pos)
        {
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = transform.position;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
