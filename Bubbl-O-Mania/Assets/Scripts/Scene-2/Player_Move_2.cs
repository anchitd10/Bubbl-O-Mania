using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_2 : MonoBehaviour
{

    public float moveForce = 10f;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Vertical");
        float moveZ = Input.GetAxis("Horizontal");

        Vector3 force = new Vector3(-moveX, 0, moveZ) * moveForce;

        // Apply the force to the Rigidbody
        rb.AddForce(force);
    }
}
