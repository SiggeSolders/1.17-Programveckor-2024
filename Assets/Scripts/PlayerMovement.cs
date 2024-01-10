using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public Transform orientetion;

    float horizontalImput;
    float verticalInput;

    Vector3 movedirection;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent < Rigidbody>();
        rb.freezeRotation = true;
    }

    
    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private void MyInput()
    {
        horizontalImput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

    }
    private void MovePlayer()
    {
        movedirection = orientetion.forward * verticalInput + orientetion.right * horizontalImput;

        rb.AddForce(movedirection * moveSpeed * 10, ForceMode.Force);
    }
}
