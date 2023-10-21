using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        Destroy(boxCollider);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
