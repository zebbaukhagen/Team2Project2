using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;  // Movement speed
    public float rotationSpeed = 0.15f;  // Speed of rotation
    public float inputThreshold = 0.1f;  // Threshold for input to be considered significant
    private Vector3 movement;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Read input from WASD keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        rb.angularVelocity = Vector3.zero;

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
}