using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    
    public Transform target;
    private Vector3 targetOffset;
    [SerializeField]
    private float movementSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        //Sets the Camera offset
        targetOffset.Set(0f, 10f, -3f);

    }

    // Update is called once per frame
    void Update()
    {
        //Calls the camera movement funtion
        MoveCamera();
    }

    void MoveCamera()
    {
        //smoothly transforms the vector (Lerp) at a set speed to follow the character
        transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, movementSpeed * Time.deltaTime); 
    }

}

