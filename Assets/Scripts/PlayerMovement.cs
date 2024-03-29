using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedChangeAmount; // The amount the speed will change
    public float maxForwardSpeed; // The maximum speed the submarine can move forwards
    public float maxBackwardSpeed; // The maximum speed the submarine can move backwards
    public float minSpeed; // The minimum speed the submarine can move before snapping to 0
    public float turnSpeed; // The speed the submarine turns left and right
    public float stabilizationSmoothing; // The smoothing applied to the correction turning
    public float riseSpeed; // The speed the submarine rises and lowers

    private float curSpeed; // The current stores forwards and backwards speed
    private Rigidbody rb; // Reference to the Rigidbody of the submarine

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Getting the Rigidbody reference
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move(); // Move the submarine forwards and backwards
        Turn(); // Turn the submarine left and rise
        Rise(); // Rise and lower the submarine
        Stabilize(); // Correct the submarine's rotation to be upright even when it knocks into objects
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W)) // When the player presses the W key
        {
            curSpeed += speedChangeAmount; // Add to the submarine's speed
        }
        else if (Input.GetKey(KeyCode.S)) // When the player presses the W key
        {
            curSpeed -= speedChangeAmount; // Subtract from the submarine's speed
        }
        else if (Mathf.Abs(curSpeed) <= minSpeed) // If the player is not pressing W or S and the current speed is less than the minumum speed
        {
            curSpeed = 0; // Snap the submarine to not move
        }
        curSpeed = Mathf.Clamp(curSpeed, -maxBackwardSpeed, maxForwardSpeed); // Clamp the current speed based on it's max values in both directions
        rb.AddForce(transform.forward * curSpeed); // Apply the force to the Rigidbody to move the submarine
    }

    void Turn()
    {
        if (Input.GetKey(KeyCode.D)) // When the player presses the D key
        {
            rb.AddTorque(transform.up * turnSpeed); // Apply torque to turn the submarine right
        }
        else if (Input.GetKey(KeyCode.A)) // When the player presses the A key
        {
            rb.AddTorque(transform.up * -turnSpeed); // Apply torque to turn the submarine left
        }
    }

    void Rise()
    {
        if (Input.GetKey(KeyCode.LeftShift)) // When the player presses the Left Shift key
        {
            rb.AddForce(transform.up * riseSpeed); // Apply force to make the submarine rise
        }
        else if (Input.GetKey(KeyCode.LeftControl)) // When the player presses the Left Control key
        {
            rb.AddForce(transform.up * -riseSpeed); // Apply force to make the submarine lower
        }
    }

    void Stabilize()
    {
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.Euler(new Vector3(0, rb.rotation.eulerAngles.y, 0)), stabilizationSmoothing)); // Smoothly and slowly rotate the submarine to be upright
    }
}