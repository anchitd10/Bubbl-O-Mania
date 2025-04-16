using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjP2 : MonoBehaviour
{
    public Animator animator;
    private GameObject grabbedObj;
    public Rigidbody rb;
    public bool alreadyGrabbing = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (!alreadyGrabbing) {
                animator.SetBool("isLeftHandUp2", true);

                if (grabbedObj == null) {
                    animator.SetBool("nothingFound2", true);
                    Invoke("NothingPicked", 1.5f); // Reset nothingFound after animation completes
                }
                else {
                    animator.SetBool("nothingFound2", false);
                    GrabObject();
                }
            }
            else {
                animator.SetBool("isLeftHandUp2", false);
                ReleaseObject();
            }
        }
    }

    private void NothingPicked()
    {
        animator.SetBool("nothingFound2", false);
        animator.SetBool("isLeftHandUp2", false);
    }

    private void GrabObject()
    {
        if (grabbedObj != null) {
            FixedJoint fj = grabbedObj.AddComponent<FixedJoint>();
            fj.connectedBody = rb;
            fj.breakForce = 5000;
            alreadyGrabbing = true;
        }
    }

    private void ReleaseObject()
    {
        if (grabbedObj != null) {
            Destroy(grabbedObj.GetComponent<FixedJoint>());
            grabbedObj = null;
            alreadyGrabbing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {
            grabbedObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == grabbedObj) {
            grabbedObj = null;
        }
    }
}
