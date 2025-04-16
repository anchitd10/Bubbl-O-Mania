using UnityEngine;

public class DynamicCamera : MonoBehaviour
{
    public Transform player1; // Reference to the first player's Transform
    public Transform player2; // Reference to the second player's Transform
    public float minFOV = 50f; // Minimum field of view
    public float maxFOV = 70f; // Maximum field of view
    public float zoomSpeed = 5f; // Speed of FOV adjustment
    public float panSpeed = 5f; // Speed of camera movement
    public float distancePadding = 2f; // Padding around the players
    public float minHeight = 10f; // Minimum height for the camera

    public string playerTag = "Player";

    private Camera cam;
    // private Transform camTransform;
    void Start()
    {
        // Get the Camera component attached to this GameObject
        cam = GetComponent<Camera>();
        // GameObject player1Object = GameObject.FindWithTag(playerTag);
        // GameObject player2Object = GameObject.FindWithTag(playerTag);
    }

    void LateUpdate()
    {
        if (player1 == null || player2 == null)
            return;

        // Calculate the midpoint between the two players
        Vector3 midpoint = (player1.position + player2.position) / 2f;

        // Calculate the distance between the players
        float distance = Vector3.Distance(player1.position, player2.position);

        // Adjust the camera's position
        Vector3 targetPosition = midpoint - transform.forward * (distance + distancePadding);

        // Clamp the height of the camera to not go below minHeight
        targetPosition.y = Mathf.Max(targetPosition.y, minHeight);

        // Smoothly move the camera to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * panSpeed);

        // Adjust the camera's field of view based on the distance
        float targetFOV = Mathf.Lerp(minFOV, maxFOV, distance / maxFOV);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, targetFOV, Time.deltaTime * zoomSpeed);
    }
}