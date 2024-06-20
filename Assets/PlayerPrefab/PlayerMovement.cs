using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Model")]
    [SerializeField] private Transform playerModel;

    [Header("Movement")]
    public float moveSpeed;
    public float rotationSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight = 2f;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientation;

    [Header("Raycast")]
    public Transform raycastOrigin; // Custom raycast origin

    [Header("Camera")]
    public Transform cameraTransform; // Reference to the camera

    Vector2 moveInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private PlayerInput playerInput;
    private InputAction moveAction;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;


        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        moveAction.Enable();
    }

    private void Update()
    {
      
        Vector3 rayOrigin = raycastOrigin ? raycastOrigin.position : transform.position;
        grounded = Physics.Raycast(rayOrigin, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

 

        SpeedControl();
        MyInput();


        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        Vector3 inputDir = cameraTransform.forward * inputVector.y + cameraTransform.right * inputVector.x;
        inputDir.y = 0; // Keep the direction strictly horizontal
        Debug.Log(inputDir);

        if (inputDir != Vector3.zero)
        {
            playerModel.forward = Vector3.Slerp(playerModel.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }

    private void MovePlayer()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        moveDirection = cameraTransform.forward * moveInput.y + cameraTransform.right * moveInput.x;
        moveDirection.y = 0; // Keep the direction strictly horizontal

        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }


}
