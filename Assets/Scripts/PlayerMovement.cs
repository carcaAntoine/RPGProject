using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5.0f;
    public float rotationSpeed;
    public float groundDistance = 0.5f;
    public float jumpForce = 300; 

    private float verticalInput, horizontalInput;
    Vector3 verticalMovement, horizontalMovement;
    public bool canMove = true;
    private bool isMoving;

    public GameObject player;
    private Animator playerAnimator;
    private Rigidbody playerRb;
    [SerializeField] private Transform cameraTransform;

    //--------------------------------------------------
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        //Get Player Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(canMove)
            MovePlayer();
    }

    //Vérifie que le Player est au sol
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);

    }

    void MovePlayer()
    {
        verticalMovement = Vector3.forward * Time.deltaTime * speed * verticalInput;
        horizontalMovement = Vector3.right * Time.deltaTime * speed * horizontalInput;


        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * movementDirection;
        movementDirection.Normalize();

        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

        }

        //----- Jump -----

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            playerRb.AddForce(new Vector3(0, jumpForce, 0));

        }

        //----- Animations -----
        if (verticalMovement != Vector3.zero || horizontalMovement != Vector3.zero)
        {
            playerAnimator.SetBool("isMoving", true);
            if(!isMoving)
            {
                isMoving = true;
            }
            //Debug.Log("I'm moving");
                
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
            isMoving = false;
            //Debug.Log("I'm not moving");
        }
    }
}
