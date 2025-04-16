using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObj : MonoBehaviour
{
    public Animator animator;
    private GameObject grabbedObj;
    public Rigidbody rb;
    public float throwForce ;
    public bool alreadyGrabbing1 = false;
    private bool canPunch = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canPunch)
        {
            if (!alreadyGrabbing1)
            {
                animator.SetBool("isLeftHandUp", true);

                if (grabbedObj == null)
                {
                    animator.SetBool("nothingFound", true);
                    Invoke("NothingPicked", 1.5f);
                }
                else
                {
                    animator.SetBool("nothingFound", false);
                    GrabObject();
                }
            }
            else
            {
                animator.SetBool("isLeftHandUp", false);
                ReleaseObject();
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && !alreadyGrabbing1 && canPunch)
        {
            animator.SetBool("isPunching", true);
            canPunch = false;
            Invoke("ResetPunch", 1.5f);
            Invoke("EnablePunch", 1f);
        }
    }

    private void NothingPicked()
    {
        animator.SetBool("nothingFound", false);
        animator.SetBool("isLeftHandUp", false);
    }

    private void GrabObject()
    {
        if (grabbedObj != null)
        {
            FixedJoint fj = grabbedObj.AddComponent<FixedJoint>();
            fj.connectedBody = rb;
            fj.breakForce = 5000;
            alreadyGrabbing1 = true;
        }
    }

    private void ReleaseObject()
    {
        if (grabbedObj != null)
        {
            Destroy(grabbedObj.GetComponent<FixedJoint>());

          
            Rigidbody enemyRb = grabbedObj.GetComponent<Rigidbody>();
            if (enemyRb != null)
            {
                Vector3 throwDirection = transform.forward + Vector3.up * 0.5f; 
                
                enemyRb.AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);
            }

            grabbedObj = null;
            alreadyGrabbing1 = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player2"))
        {
            grabbedObj = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == grabbedObj)
        {
            grabbedObj = null;
        }
    }

    private void ResetPunch()
    {
        animator.SetBool("isPunching", false);
    }

    private void EnablePunch()
    {
        canPunch = true;
    }
}
