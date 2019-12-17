using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{

    [SerializeField]
    private bool _isGrounded = false;

    private PlayerMotor motor;
    private PlayerController controller;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        motor = GetComponent<PlayerMotor>();
    }

    private void FixedUpdate()
    {
        motor.Fall(_isGrounded);
        controller.Grounded(_isGrounded);
    }
    
    //This event is triggered when the player is touching anything with the "Ground" tag. This allows us to detect if the player is in the air or not
    public void OnCollisionEnter(Collision theCollision)
    { 
        if (theCollision.gameObject.tag == "Ground")
        {
            //If the player is touching an item with the "Ground" tag, it writes the isGrounded bool to true, allowing us to reference isGrounded for anything that should be effected by this
            _isGrounded = true;
        }
    }

    //This event is triggered when the player leaves anything with the "Ground" tag. This allows us to detect if the player is in the air    
    public void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            //If the player isn't touching an item with the "Ground" tag, it writes the isGrounded bool to false, allowing us to determine that the player is in the air
            _isGrounded = false;
        }
        
    }

        
}
