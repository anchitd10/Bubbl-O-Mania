using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;

    public float boostedMoveSpeed = 20f;
    public float slowedMoveSpeed = 5f;
    public float bubbleForce = 15f;


    public Rigidbody hips;
    public bool isGrounded;

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

    private float timeOnBouncePad = 0f;
    private bool isOnBouncePad = false;
    public float bounceDelay = 3f;

    private bool isOnSpeedPad = false;
    private bool isOnSlowPad = false;

    audiomanager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audiomanager>();
    }

    void Start()
    {
        hips = GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {
        float boostedStrafeSpeed = strafeSpeed;
        float currentMoveSpeed = speed;
        float currentStrafeSpeed = speed;

        if (isOnSpeedPad)
        {
            currentMoveSpeed = boostedMoveSpeed;
            currentStrafeSpeed = boostedStrafeSpeed;
        }
        else if (isOnSlowPad)
        {
            currentMoveSpeed = slowedMoveSpeed;
        }


        if (Input.GetKey(KeyCode.D)) {

            if (Input.GetKey(KeyCode.LeftShift)) {
                // hips.AddForce(hips.transform.forward * speed * 1.5f);
                hips.AddForce(hips.transform.forward * currentMoveSpeed * 1.5f);

            }
            else {
                // hips.AddForce(hips.transform.forward * speed);
                hips.AddForce(hips.transform.forward * currentMoveSpeed);
            }


        }

        if (Input.GetKey(KeyCode.W)) {
            // hips.AddForce(-hips.transform.right * strafeSpeed);
            hips.AddForce(-hips.transform.right * currentStrafeSpeed);
        }

        if (Input.GetKey(KeyCode.S)) {
            // hips.AddForce(hips.transform.right * strafeSpeed);
            hips.AddForce(hips.transform.right * currentStrafeSpeed);
        }
        if (Input.GetKey(KeyCode.A)) {
            // hips.AddForce(-hips.transform.forward * speed);
            hips.AddForce(-hips.transform.forward * currentMoveSpeed);
        }

        /*if (Input.GetAxis("Jump") > 0) {

            if (isGrounded) {
                hips.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }*/

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
            hips.AddForce(forceDirection * bubbleForce, ForceMode.Impulse);

            Debug.Log("Player forced away from bubble in the opposite direction of collision!");
        }

        /*
        if (collision.gameObject.CompareTag("Bubble-Obstacle"))
        {
            Debug.Log("Game Over");
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Game Over");
        }
        */
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
        hips.AddForce(Vector3.up * bounceForce, ForceMode.Impulse);
        Debug.Log("Bounced after staying for 3 seconds!");
    }
}