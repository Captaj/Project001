using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMotor : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private Vector3 jumpForce = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Jump(Vector3 _jumpForce)
    {
        jumpForce = _jumpForce;
    }


    private void FixedUpdate()
    {
        PerformMovement();
        PerformJump();
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        if (jumpForce != Vector3.zero)
        {
            
        }
    }

    public void PerformJump()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }

}
