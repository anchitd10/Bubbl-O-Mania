using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeMovement : MonoBehaviour
{
    public float moveForce = 10f;
    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /*
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        switch (hit.gameObject.tag)
        {
            case "SpeedBoost":
                moveSpeed = 25f;
                break;
            case "JumpPad":
                jumpSpeed = 25f;
                break;
            case "Ground":
                jumpSpeed = 25f;
                break;
        }
    }
    */
}
