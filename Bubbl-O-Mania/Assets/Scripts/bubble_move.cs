using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class bubble_move : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] float speed;

    private Vector3 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Transform spawner = transform.parent; // Assuming prefab is spawned as a child of the spawner
        if (spawner != null)
        {
            // Set moveDirection based on the spawner's forward direction
            moveDirection = spawner.forward;
        }
        else
        {
            // Default move direction if no parent is found
            moveDirection = Vector3.forward;
        }
    }

    void Update()
    {
        // Move the object in the specified direction
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    /*
    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + forwardMove);
    }
    */
}
