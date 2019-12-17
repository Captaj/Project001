using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    private PlayerMotor motor;
    private PlayerState state;


    [SerializeField]
    private float playerSpeed = 5f;
    [SerializeField]
    private float speedMod = 1f;
    [SerializeField]
    private float jumpForce = 200f;
    private bool isGrounded = false;
    [SerializeField]
    private bool isWalking = true;
    [SerializeField]
    private float crouchMod = 0.5f;
    [SerializeField]
    private float sprintMod = 2f;

    

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
        state = GetComponent<PlayerState>();
    }

    [SerializeField]
    private Vector3 _velocity = Vector3.zero;

    void Update()
    {
        
        
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        HandleRotationInput();

        _velocity = new Vector3((_xMov * playerSpeed * speedMod), 0, (_yMov * playerSpeed * speedMod));

        motor.Move(_velocity);

        Vector3 _jumpForce = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            _jumpForce = new Vector3(0, jumpForce, 0);
            isGrounded = false;
        }

        //If the player presses left shift while grounded, then they activate the sprint button
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded == true)
        {
            HandleSprint();
        }

        //If the player presses left control while grounded, then they activate the crouch button
        if (Input.GetKey(KeyCode.LeftControl) && isGrounded == true)
        {
            HandleCrouch();
        }

        //if the isWalking condition is true, then it sets the speed modifier to 1
        if (isWalking == true)
        {
            speedMod = 1f;
        }

        //If the player isn't holding down the sprint or crouch button, then it sets walking to true
        if (Input.GetKey(KeyCode.LeftShift) == false && Input.GetKey(KeyCode.LeftControl) == false)
        {
            isWalking = true;
        }

        motor.Jump(_jumpForce);

    }

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

    public void Grounded(bool _isGrounded)
    {
        isGrounded = _isGrounded;
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
