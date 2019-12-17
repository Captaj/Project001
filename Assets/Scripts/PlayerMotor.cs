using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerState))]

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private Vector3 jumpForce = Vector3.zero;
    private bool isGrounded = false;
    [SerializeField]
    private float freeFall = 20f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        PerformMovement();

        if (isGrounded == false)
        {
            rb.AddForce(new Vector3(0, -(freeFall), 0), ForceMode.Acceleration);
        }
    }

    [SerializeField]
    
    public void Move(Vector3 _velocity)
    {
        
        velocity = _velocity;
    }

    public void Jump(Vector3 _jumpForce)
    {
        jumpForce = _jumpForce;
    }

    public void Fall(bool _isGrounded)
    {
        isGrounded = _isGrounded;
    }
    

    void PerformMovement()
    {
        rb.AddForce(velocity); // * Time.fixedDeltaTime, ForceMode.Force);
        

        if (isGrounded == true)
        {
            rb.AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    

}
