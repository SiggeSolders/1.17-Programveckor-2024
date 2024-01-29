using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public StamminaControler _stamminaControler;
    [Header("Movement")]
    private float moveSpeed;
    public float walkspeed;
    public float sprintspeed;

    public float groundDrag;




    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool Grounded;
    
    public bool runCooldown = false;

    public Transform orientetion;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;
    public enum MovementState
    {
        walking,
        sprinting,
        air
    }
    void Start()
    {
        _stamminaControler = GetComponent<StamminaControler>();
        rb = GetComponent < Rigidbody>();
        rb.freezeRotation = true;
        readyToJump = true;
    }

    public void setRunsSpeed(float speed)
    {
        moveSpeed = speed;
    }
    // Update is called once per frame
    void Update()
    {
        //Ground Check
        Grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        Debug.DrawRay(transform.position, Vector3.down * (playerHeight * 0.5f + 0.2f));
        MyInput();
        SpeedControl();
        StateHandler();

        //Drag
        if (Grounded)
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
    
    private void StateHandler()
    {
        if(Grounded && Input.GetKey(sprintKey) && _stamminaControler.playerStammina > 0 && runCooldown == false)
        {
            state = MovementState.sprinting;
            moveSpeed = sprintspeed;

        }else if (Grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkspeed;
        }
        else
        {
            state = MovementState.air;
        }
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if(state == MovementState.sprinting)
        {
            if(_stamminaControler.playerStammina > 0)
            {
                _stamminaControler.isSprinting = true;
                _stamminaControler.IsSprinting();
            }
        }
        if(state == MovementState.walking)
        {
            _stamminaControler.isSprinting = false;
        }
        //Jump
        if (Input.GetKey(jumpKey) && readyToJump && Grounded)
        {
            _stamminaControler.StamminaJump();
        }
    }

    public void PlayerJump()
    {
        readyToJump = false;

        Jump();

        Invoke(nameof(ResetJump), jumpCooldown);
    }
    private void MovePlayer()
    {
        moveDirection = orientetion.forward * verticalInput + orientetion.right * horizontalInput;

        //On ground
        if (Grounded)
        {
            rb.AddForce(moveDirection * moveSpeed * 10, ForceMode.Force);
        }

        //In Air
        else if (!Grounded)
        {
            rb.AddForce(moveDirection * moveSpeed * 10 * airMultiplier, ForceMode.Force);
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
    
    private void Jump()
    {
        
        // Kollar Y
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}
