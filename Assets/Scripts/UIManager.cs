using UnityEngine;
using TMPro;

public class PlayerInfoUI : MonoBehaviour
{
    public TextMeshProUGUI speedTextTMP;
    public TextMeshProUGUI locationTextTMP;
    public Rigidbody playerRigidbody;

    void Update()
    {
        // Update speed - assuming speed is the magnitude of the velocity vector
        speedTextTMP.text = "Speed: " + playerRigidbody.velocity.magnitude.ToString("F2") + " m/s";

        // Update location
        locationTextTMP.text = "Location: " + playerRigidbody.position.ToString("F2");
    }
}
