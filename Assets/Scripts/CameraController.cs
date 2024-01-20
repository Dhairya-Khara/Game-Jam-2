using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset; // Offset from the player
    public float smoothFactor = 0.5f;

    void FixedUpdate()
    {
        // Calculate the desired position of the camera
        Vector3 desiredPosition = playerTransform.position + playerTransform.TransformDirection(offset);
        
        // Smoothly interpolate between the camera's current position and the desired position
        transform.position = Vector3.Slerp(transform.position, desiredPosition, smoothFactor);

        // Make the camera look in the same direction as the player
        transform.rotation = Quaternion.Slerp(transform.rotation, playerTransform.rotation, smoothFactor);
    }
}
