using UnityEngine;

public class AirplaneLaneMovement : MonoBehaviour
{
    public float speed = 10f;           // Speed of the airplane
    public float laneLength = 50f;     // Length of the lane
    public float returnDelay = 15f;    // Time to wait before returning

    private Vector3 startPosition;     // Initial position of the airplane
    private bool isReturning = false;  // Tracks if the plane is returning

    void Start()
    {
        // Store the initial position of the airplane
        startPosition = transform.position;
    }

    void Update()
    {
        // Move the airplane forward along the lane
        if (!isReturning)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

            // Check if the airplane has reached the end of the lane
            if (Vector3.Distance(transform.position, startPosition) >= laneLength)
            {
                StartCoroutine(ReturnToLane());
            }
        }
    }

    private System.Collections.IEnumerator ReturnToLane()
    {
        // Stop movement and set return flag
        isReturning = true;

        // Wait for the specified delay
        yield return new WaitForSeconds(returnDelay);

        // Reset airplane to its starting position
        transform.position = startPosition;

        // Resume movement
        isReturning = false;
    }
}
