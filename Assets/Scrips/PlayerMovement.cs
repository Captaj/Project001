﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    private Rigidbody rb;

    private Vector3 moveinput;
    private Vector3 moveVelocity;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        moveinput = new Vector3(Input.GetAxisRaw("Horizontal"),0f,Input.GetAxisRaw("Vertical")); //getaxisraw for precise movement, instantly stops movement when keys stop being pressed
        moveVelocity = moveinput * moveSpeed;
        
        Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition); //creates line going from camera to mouse position
        Plane groundplane = new Plane(Vector3.up, Vector3.zero);
        float raylength;

        if(groundplane.Raycast(cameraRay,out raylength)) //checking to see if ray hits something and if it does outputs raylength
        {
            Vector3 pointTolook = cameraRay.GetPoint(raylength);
            Debug.DrawLine(cameraRay.origin, pointTolook, Color.blue);

            transform.LookAt(new Vector3(pointTolook.x,transform.position.y,pointTolook.z));
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = moveVelocity;
    }
}
