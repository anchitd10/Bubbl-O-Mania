using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapEffect : MonoBehaviour
{
    public float slapForce = 500f;
    public float radius = 5f;
    public Vector3 slapDirection = Vector3.back;

    audiomanager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audiomanager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player2"))
        {
            Rigidbody rb = collision.collider.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 forceDirection = (collision.collider.transform.position - transform.position).normalized;
                forceDirection = new Vector3(forceDirection.x, 0.5f, forceDirection.z);
                audioManager.PlaySFX(audioManager.Punch_Pop);
                rb.AddForce(forceDirection * slapForce, ForceMode.Impulse);
            }
        }
    }
}
