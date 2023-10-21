using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //No podemos hacer el GetComponent porque player está en otro script
    [SerializeField] private Transform player;
    private PlayerMovement playerMovement;
    private Camera mainCamera;
    private SpriteRenderer sr;
    private float leftCameraEdge;
    private float rightCameraEdge;

    private bool cameraMoving = false;

    [SerializeField] private GameObject cameraMinBoundary;
    [SerializeField] private GameObject cameraMaxBoundary;



    // Update is called once per frame

    private void Start()
    {
        mainCamera = Camera.main;

        playerMovement = player.GetComponent <PlayerMovement>();
        sr = player.GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        float halfOrthographicWidth = mainCamera.orthographicSize * mainCamera.aspect;
        leftCameraEdge = mainCamera.transform.position.x - halfOrthographicWidth;
        rightCameraEdge = mainCamera.transform.position.x + halfOrthographicWidth;

        //Debug.Log("RightCameraEdge" + rightCameraEdge);
        //Debug.Log("CameraMax" + cameraMaxBoundary.transform.position.x);



        if (rightCameraEdge > cameraMaxBoundary.transform.position.x && playerMovement.directionX > 0f)
        {
            cameraMoving = false;
        }


        else if (player.transform.position.x > cameraMinBoundary.transform.position.x)
        {
            cameraMoving = true;
        }

        else 
        {
            cameraMoving = false;
        }

        toggleCamera();

    }

    private void toggleCamera()
    {
        if(cameraMoving == true && playerMovement.directionX != 0f)
        {
            if(playerMovement.directionX > 0f)
            {
                Vector3 newPosition = new Vector3(transform.position.x + playerMovement.moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.position = newPosition;
            }

            else
            {
                Vector3 newPosition = new Vector3(transform.position.x - playerMovement.moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
                transform.position = newPosition;
            }
        }
    }


}
