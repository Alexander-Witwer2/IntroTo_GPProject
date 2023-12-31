using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplyer;
    public bool readyToJump;

    [Header("Keybindings")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    public bool grounded;

    public Transform ori;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start(){
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
        //grounded = true;
    }

    private void Update(){
        //This is to check if the player is on the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight *0.5f + 0.2f, whatIsGround);

        MyInput();
        SpeedControl();
        if(grounded)// if on the ground
            rb.drag = groundDrag*2;
        else
            rb.drag = 0;
    }

    private void FixedUpdate(){
        movePlayer();
    }

    private void MyInput(){
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded){
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump),jumpCooldown);
        }
    }

    private void movePlayer(){
        moveDirection = ori.forward * verticalInput + ori.right * horizontalInput;//calculates movement direction

        if(grounded) //On the ground
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        else if(!grounded)// In the air
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplyer, ForceMode.Force);

    }

    private void SpeedControl(){
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limiting velocity
        if(flatVel.magnitude > moveSpeed){
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump(){
        //reset the y velocity
        //rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //rb.AddForce(transform.up *jumpForce, ForceMode.Impulse);
    }

    private void ResetJump(){
        readyToJump = true;
    }
}
