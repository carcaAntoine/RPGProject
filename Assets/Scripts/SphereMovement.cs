using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMovement : MonoBehaviour
{

    public float speed = 5.0f;
    private float verticalInput, horizontalInput;
    Vector3 verticalMovement, horizontalMovement;
    private Rigidbody playerRb;
    [SerializeField] private Transform cameraTransform;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Get Player Inputs
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        MovePlayer();
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
    }
}