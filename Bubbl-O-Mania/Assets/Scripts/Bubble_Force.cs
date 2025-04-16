using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble_Force : MonoBehaviour
{
    audiomanager audioManager;

    public float bubbleForce = 15f;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audiomanager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            // Get the Rigidbody of the other object
            Rigidbody otherRigidbody = collision.rigidbody;

            if (otherRigidbody != null)
            {
                // Calculate the direction to push the other object
                Vector3 collisionDirection = collision.contacts[0].point - transform.position;

                // Restrict the direction to the XZ plane
                collisionDirection = new Vector3(collisionDirection.x, 0, collisionDirection.z).normalized;

                // Apply force to the other object in the XZ plane
                audioManager.PlaySFX(audioManager.Bubble_Thrust);
                otherRigidbody.AddForce(collisionDirection * bubbleForce, ForceMode.Impulse);
                Debug.Log("Force Applied");
            }
        }
    }
}
