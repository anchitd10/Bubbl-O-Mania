using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float speed;
    public float strafeSpeed;
    public float jumpForce;


    public Rigidbody hips;
    public bool isGrounded;
    void Start()
    {
        hips = GetComponent<Rigidbody>();

    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.I)) {

            if (Input.GetKey(KeyCode.LeftShift)) {
                hips.AddForce(hips.transform.forward * speed * 1.5f);

            }
            else {
                hips.AddForce(hips.transform.forward * speed);
            }


        }

        if (Input.GetKey(KeyCode.J)) {

            hips.AddForce(-hips.transform.right * strafeSpeed);
        }

        if (Input.GetKey(KeyCode.L)) {

            hips.AddForce(hips.transform.right * strafeSpeed);
        }
        if (Input.GetKey(KeyCode.K)) {

            hips.AddForce(-hips.transform.forward * speed);
        }

        if (Input.GetAxis("Jump") > 0) {

            if (isGrounded) {
                hips.AddForce(new Vector3(0, jumpForce, 0));
                isGrounded = false;
            }
        }


    }
}