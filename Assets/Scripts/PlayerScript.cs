using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5f;
    private Rigidbody rb;

    private Vector3 inputVector;
    [SerializeField]
    private bool isGrounded = false;
    [SerializeField]
    private float jumpForce = 200f;
    [SerializeField]
    private float freeFall = -20f;
    [SerializeField]
    private float sprintMod = 1.5f;
    [SerializeField]
    private float crouchMod = 0.5f;

    [SerializeField]
    private float speedMod = 1f;
    [SerializeField]
    private bool isWalking = true;

    // Start is called before the first frame update
    void Start()
    {
        //Grabs the physics model for the player movement
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calls the function below to handle curser facing rotation
        HandleRotationInput();
        //Checks to see if the player is on the ground, and if the jump button (Space) is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        { 
            //Calls the Jump function below
            HandleJump();
        }

        //If the player is not grounded, then the player is pushed down
        if (isGrounded == false)
        {
            rb.AddForce(new Vector3(0, freeFall, 0), ForceMode.Acceleration);
        }

        //If the player presses left shift while grounded, then they activate the sprint button
        if (isGrounded == true && Input.GetKey(KeyCode.LeftShift))
        {
            HandleSprint();
        }
        
        //If the player presses left control while grounded, then they activate the crouch button
        if (isGrounded == true && Input.GetKey(KeyCode.LeftControl))
        {
            HandleCrouch();
        }

        //if the isWalking condition is true, then it sets the speed modifier to 1
        if(isWalking == true)
        {
            speedMod = 1f;
        }

        //If the player isn't holding down the sprint or crouch button, then it sets walking to true
        if(Input.GetKey(KeyCode.LeftShift) == false && Input.GetKey(KeyCode.LeftControl) == false)
        {
            isWalking = true;
        }

    }

  

    private void FixedUpdate()
    {
        //If the player is on the ground, then the player controls function normally
        if(isGrounded == true)
        {
            //The the vector is taken from the horizontal and vertical button presses and multiplied by the speed veriable
            inputVector = new Vector3(Input.GetAxis("Horizontal") * playerSpeed * speedMod, 0, Input.GetAxis("Vertical") * playerSpeed * speedMod);
            //the input vector from above is taken and used as the new movement velocity for the rigidbody physics
            rb.velocity = (inputVector);
        }

    }

    //This event is triggered when the player is touching anything with the "Ground" tag. This allows us to detect if the player is in the air or not
    public void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Ground")
        {
            //If the player is touching an item with the "Ground" tag, it writes the isGrounded bool to true, allowing us to reference isGrounded for anything that should be effected by this
            isGrounded = true;
        }
    }

    //This event is triggered when the player leaves anything with the "Ground" tag. This allows us to detect if the player is in the air    
    public void OnCollisionExit(Collision theCollision)
    {
        if(theCollision.gameObject.tag == "Ground")
        {
            //If the player isn't touching an item with the "Ground" tag, it writes the isGrounded bool to false, allowing us to determine that the player is in the air
            isGrounded = false; 
        }
    }



    //This function handles rotion of the character in relation to the mouse
    void HandleRotationInput()
    {
        RaycastHit _hit;
        //A ray is sent out from the camera to the mouse pointer
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //If the ray hits something
        if (Physics.Raycast(_ray, out _hit))
        {
            //We take the point of the mouse and rotate the player to look at it
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }

        

    }
    //This is the jump function, and is called from above is the player is on the ground and the Space bar is pressed
    private void HandleJump()
    { 
        //Using ridgidBody, we apply an impulse of "jumpForce" to the player directly up. THis still maintains any momentum that the player has
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        //I don't know why this needs to be here for the jump to feel better, but it feels way different if it isn't. I am guessing it doesn't detect if it isn't grounded fast enough normally. 
        isGrounded = false;
    }


    //This functions the sprint modifier for the character
    private void HandleSprint()
    {
        //sets the movement modifer to equal the sprint float, as well as setting the isWalking to false, so the game won't try and set the speed modifier back to 1
        speedMod = sprintMod;
        isWalking = false;
    }

    //This functions the crouch modifier for the character
    private void HandleCrouch()
    {
        //sets the movement modifer to equal the crouch float, as well as setting the isWalking to false, so the game won't try and set the speed modifier back to 1
        speedMod = crouchMod;
        isWalking = false;
    }

}
