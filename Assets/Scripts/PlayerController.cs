using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 5f;

    private PlayerMotor motor;

    [SerializeField]
    private float speedMod = 1f;

    [SerializeField]
    private float jumpForce = 100f;

    [SerializeField]
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _yMov = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = Vector3.right * _xMov;
        Vector3 _moveVertical = Vector3.forward * _yMov;

        Vector3 _velocity = (_moveHorizontal + _moveVertical) * playerSpeed * speedMod;

        motor.Move(_velocity);

        Vector3 _jumpForce = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            _jumpForce = Vector3.up * jumpForce;
        }

        motor.Jump(_jumpForce);

    }
}
