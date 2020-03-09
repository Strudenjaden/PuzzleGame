using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    [Header("Movement")]
    public float speed;
    private float walkSpeed = 5;
    private float runSpeed = 10;
    public bool isRunning = false;
    Vector3 movement = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

    }

    void Move()
    {
        //Making easy movement to the player.
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");
        movement = new Vector3(moveH * speed, rb.velocity.y, moveV * speed);

        //Movement where the Main Camera is looking at;
        movement = Camera.main.transform.TransformDirection(movement);
        movement.y = 0.0f;

        //Moving the rigidbody.
        rb.velocity = movement;
        

        //Making player run
        if (Input.GetKey(KeyCode.LeftShift) && moveV >= 0)
        {
            speed = runSpeed;
            isRunning = true;
            Debug.Log("Running");
        } else
        {
            speed = walkSpeed;
            isRunning = false;
            Debug.Log("Not running");
        }
    }
}
