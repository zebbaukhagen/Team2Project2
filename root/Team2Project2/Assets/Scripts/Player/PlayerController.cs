using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;  // Movement speed
    [SerializeField] private float rotationSpeed = 0.15f;  // Speed of rotation
    [SerializeField] private AudioSource audioSource;
    private float inputThreshold = 0.1f;  // Threshold for input to be considered significant
    private Vector3 movement;
    private Rigidbody rb;
    private Vector3 lastPosition;   // Stores the last position of the player

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastPosition = transform.position; // Initialize lastPosition
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Read input from WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.angularVelocity = Vector3.zero;
        CheckForMovement();

        // Check if the input is above the threshold
        if (Mathf.Abs(horizontalInput) > inputThreshold || Mathf.Abs(verticalInput) > inputThreshold)
        {
            // Calculate the movement vector
            movement = new Vector3(horizontalInput, 0f, verticalInput);
            if (movement != Vector3.zero)
            {
                Quaternion desiredRotation = Quaternion.LookRotation(movement);
                rb.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, rotationSpeed);

                // Move the player
                rb.MovePosition(rb.position + speed * Time.deltaTime * movement);
            }
        }
    }

    private void CheckForMovement()
    {
        // Check if the player has moved
        if (transform.position != lastPosition)
        {
            // Player is moving
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // Start the audio loop
            }
        }
        else
        {
            // Player has stopped moving
            if (audioSource.isPlaying)
            {
                audioSource.Stop(); // Stop the audio loop
            }
        }

        lastPosition = transform.position; // Update lastPosition for the next frame
    }
}