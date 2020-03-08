using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    [Header("Velocities")]
    public float speed;
    public float walkSpeed = 3;
    public float runSpeed = 6;
    public bool isRunning = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();

    }

    void Movement()
    {
        //Making easy movement to the player.
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(moveH * speed, rb.velocity.y, moveV * speed);
        Debug.Log(moveV);

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
