using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Objects")]
    public Rigidbody rb;
    public Camera mainCamera;

    [Header("Movement")]
    public float speed;
    private float walkSpeed = 5f;
    private float runSpeed = 8f;
    private float backwardsSpeed = 2f;
    public bool isRunning = false;
    Vector3 movement = Vector3.zero;
    float moveH, moveV; //Inputs
    float jumpForce = 20f;

    void Update()
    {
        //Input
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
    }


    void FixedUpdate()
    {

        Move();
        Jump();
    }

    void Move()
    {
        //Velocities
        speed = walkSpeed; //The normal player velocity.
        Backwards();
        Run();
        Debug.Log("Velocidad: " + speed);


        //Making easy movement to the player.
        movement = new Vector3(moveH, rb.velocity.y, moveV);
        //Movement where the Main Camera is looking at;
        movement = mainCamera.transform.TransformDirection(movement);
        //movement.y = 0.0f;
        //Moving the rigidbody. Put this always at the end of the code to make the player walk.
        rb.velocity = movement * speed;
    }

    void Run()
    {
        //Making player run
        if (Input.GetKey(KeyCode.LeftShift) && moveV >= 0)
        {
            speed = runSpeed;
            isRunning = true;
            Debug.Log("Running");
        }else

        //if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isRunning = false;
        }
    }
    void Backwards()
    {
        //Making player walking slower when is going backwards.
        if (moveV < 0)
        {
            speed = backwardsSpeed;
        }
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
