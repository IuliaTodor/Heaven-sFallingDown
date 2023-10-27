using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialPosition : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject enterScene;
    public int pos;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");

        //player.transform.position = new Vector3(enterScene.transform.position.x, enterScene.transform.position.y, enterScene.transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
