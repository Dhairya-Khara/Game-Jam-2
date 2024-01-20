using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour
{
    public float rotationSpeed = 2f; // Adjust the speed of rotation as needed
    public float radius = 2f; // Set the radius of the circular path
    public float speed = 2f;  // Set the speed of movement

    private float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }




    void Update()
    {
        // Calculate the new position in a circular path
        float x = Mathf.Cos(angle) * radius;
        float z = Mathf.Sin(angle) * radius;

        // Set the position of the object
        transform.position = new Vector3(x, 0f, z);

        // Increment the angle based on time and speed
        angle += speed * Time.deltaTime;

        // Wrap the angle to keep it within reasonable bounds
        if (angle > 360f)
        {
            angle -= 360f;
        }
    }
}
