using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move_diff : MonoBehaviour
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
        float moveX = 0;
        float moveZ = 0;

        if (Input.GetKey(KeyCode.I)) moveX = -1f;   // Forward
        if (Input.GetKey(KeyCode.K)) moveX = 1f;  // Backward
        if (Input.GetKey(KeyCode.J)) moveZ = -1f;  // Left
        if (Input.GetKey(KeyCode.L)) moveZ = 1f;   // Right

        Vector3 force = new Vector3(moveX, 0, moveZ) * moveForce;
        rb.AddForce(force);
    }
}
