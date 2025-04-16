using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapEffectP2 : MonoBehaviour
{
    public float slapForce = 500f;
    public float radius = 5f;
    public Vector3 slapDirection = Vector3.back;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player1"))
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 forceDirection = (collision.collider.transform.position - transform.position).normalized;
                forceDirection = new Vector3(forceDirection.x, 0.5f, forceDirection.z);
                rb.AddForce(forceDirection * slapForce, ForceMode.Impulse);
            }
        }
    }
}
