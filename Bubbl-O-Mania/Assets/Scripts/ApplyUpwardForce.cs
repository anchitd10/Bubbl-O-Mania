using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyUpwardForce : MonoBehaviour
{
    public float upwardForce = 10f; // Public reference to set the upward force from the Inspector

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Bubble"
        if (collision.gameObject.CompareTag("Bubble"))
        {
            // Get the Rigidbody component of this GameObject
            Rigidbody rb = GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Apply an upward force
                rb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
            }
        }
    }
}
