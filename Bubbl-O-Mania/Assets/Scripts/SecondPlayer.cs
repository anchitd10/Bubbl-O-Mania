using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlayer : MonoBehaviour
{
    // public Vector3 startForce;

    audiomanager audioManager;

    public float moveForce = 10f; // Force applied for movement
    public float boostedMoveForce = 20f;
    public float slowedMoveForce = 5f;
    public float bubbleForce = 15f;
    public float moveSpeed = 5f;
    private Rigidbody rb; // Reference to the Rigidbody component

    public float bounceForce = 500f; // Force applied to bounce upward
    public string bounceObjectTag = "Jump-Pad";
    public string speedPadTag1 = "Speed-Pad";
    public string speedPadTag2 = "Speed-Pad";
    public string slowPadTag = "Slow-Pad";
    public string spawnerPlatformTag = "Speed-Pad";

    // public ObjectSpawner spawner;
    public ObjectSpawner spawner1; // First spawner
    public ObjectSpawner spawner2; // Second spawner

    public string spawner1PlatformTag = "SpawnerPlatform1"; // Platform for spawner1
    public string spawner2PlatformTag = "SpawnerPlatform2"; // Platform for spawner2

    private float timeOnBouncePad = 0f; // Timer to track time on the bounce pad
    private bool isOnBouncePad = false; // Flag to check if the player is on the bounce pad
    public float bounceDelay = 3f; // Time required on the pad to trigger the bounce

    private bool isOnSpeedPad = false;
    private bool isOnSlowPad = false;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audiomanager>();
    }

    void Start()
    {
        // -------------testing----------
        // Rigidbody rigidbody = GetComponent<Rigidbody>();
        // rigidbody.AddForce(startForce, ForceMode.Impulse);

        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input for horizontal (A/D or Left/Right) and vertical (W/S or Up/Down)
        // float moveX = Input.GetAxis("Horizontal");
        // float moveZ = Input.GetAxis("Vertical");


        float moveZ = 0f; // Forward/Backward
        float moveX = 0f; // Left/Right

        // Update the player's position directly
        //Vector3 movement = new Vector3(-moveX, 0, moveZ) * moveSpeed * Time.fixedDeltaTime;
        // transform.position += movement;

        if (Input.GetKey(KeyCode.I)) moveX = -1f;   // Forward
        if (Input.GetKey(KeyCode.K)) moveX = 1f;  // Backward
        if (Input.GetKey(KeyCode.J)) moveZ = -1f;  // Left
        if (Input.GetKey(KeyCode.L)) moveZ = 1f;   // Right


        float currentMoveForce = moveForce;

        if (isOnSpeedPad)
        {
            currentMoveForce = boostedMoveForce;
        }
        else if (isOnSlowPad)
        {
            currentMoveForce = slowedMoveForce;
        }


        if (isOnSpeedPad)
        {
            currentMoveForce = boostedMoveForce;
        }
        else if (isOnSlowPad)
        {
            currentMoveForce = slowedMoveForce;
        }

        // Calculate the force vector based on input
        Vector3 force = new Vector3(moveX, 0, moveZ) * currentMoveForce;

        // Apply the force to the Rigidbody
        rb.AddForce(force);

        // Check if the player is on the bounce pad
        if (isOnBouncePad)
        {
            timeOnBouncePad += Time.fixedDeltaTime;

            // If the player has been on the pad long enough, bounce them
            if (timeOnBouncePad >= bounceDelay)
            {
                BouncePlayer();
                timeOnBouncePad = 0f; // Reset the timer
            }
        }
    }

    /*
    void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with the bounce object
        if (collision.gameObject.CompareTag(bounceObjectTag))
        {
            // Apply an upward force to the player's Rigidbody
            rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        }
    }
    */

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with the bounce object
        if (collision.gameObject.CompareTag(bounceObjectTag))
        {
            isOnBouncePad = true;
        }

        if (collision.gameObject.CompareTag(speedPadTag1) || collision.gameObject.CompareTag(speedPadTag2))
        {
            isOnSpeedPad = true;
        }

        if (collision.gameObject.CompareTag(slowPadTag))
        {
            isOnSlowPad = true;
        }

        /*
        if (collision.gameObject.CompareTag(spawnerPlatformTag) && spawner != null)
        {
            spawner.StartSpawning();
        }
        */

        // Handle first spawner
        if (collision.gameObject.CompareTag(spawner1PlatformTag) && spawner1 != null)
        {
            spawner1.StartSpawning();
        }

        // Handle second spawner
        if (collision.gameObject.CompareTag(spawner2PlatformTag) && spawner2 != null)
        {
            spawner2.StartSpawning();
        }


        if (collision.gameObject.CompareTag("Bubble"))
        {
            // Get the collision contact point normal
            Vector3 collisionNormal = collision.GetContact(0).normal;

            // Calculate the force in the opposite direction
            Vector3 forceDirection = -collisionNormal.normalized;

            // Apply the force to the player
            audioManager.PlaySFX(audioManager.Bubble_Thrust);
            rb.AddForce(forceDirection * bubbleForce, ForceMode.Impulse);

            Debug.Log("Player forced away from bubble in the opposite direction of collision!");
        }

        if (collision.gameObject.CompareTag("Bubble-Obstacle"))
        {
            Debug.Log("Game Over");
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Game Over");
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // Reset the timer when the player leaves the bounce pad
        if (collision.gameObject.CompareTag(bounceObjectTag))
        {
            isOnBouncePad = false;
            timeOnBouncePad = 0f;
        }

        if (collision.gameObject.CompareTag(speedPadTag1) || collision.gameObject.CompareTag(speedPadTag2))
        {
            isOnSpeedPad = false;
        }

        /*
        if (collision.gameObject.CompareTag(spawnerPlatformTag) && spawner != null)
        {
            spawner.StopSpawning();
        }
        */

        // Stop spawning for spawner1
        if (collision.gameObject.CompareTag(spawner1PlatformTag) && spawner1 != null)
        {
            spawner1.StopSpawning();
        }

        // Stop spawning for spawner2
        if (collision.gameObject.CompareTag(spawner2PlatformTag) && spawner2 != null)
        {
            spawner2.StopSpawning();
        }
    }

    void BouncePlayer()
    {
        // Apply an upward force to the player's Rigidbody
        audioManager.PlaySFX(audioManager.Launch);
        rb.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        Debug.Log("Bounced after staying for 3 seconds!");
    }
}
