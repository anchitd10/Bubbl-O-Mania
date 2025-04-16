using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObj2 : MonoBehaviour
{
    public Animator animator;
    private GameObject grabbedObj;
    public Rigidbody rb;
    public float throwForce;
    public bool alreadyGrabbing2 = false;
    private bool canPunch = true;
    private bool isPunching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U) && !isPunching)
        {
            if (!alreadyGrabbing2)
            {
                animator.SetBool("isLeftHandUp2", true);

                if (grabbedObj == null)
                {
                    animator.SetBool("nothingFound2", true);
                    Invoke("NothingPicked", 1.5f);
                }
                else
                {
                    animator.SetBool("nothingFound2", false);
                    GrabObject();
                }
            }
            else
            {
                animator.SetBool("isLeftHandUp2", false);
                ReleaseObject();
            }
        }

        if (Input.GetKeyDown(KeyCode.O) && !alreadyGrabbing2 && canPunch && !isPunching)
        {
            isPunching = true;
            canPunch = false;
            animator.SetBool("isPunching", true);

            Invoke("ResetPunch", 1f);
            Invoke("EnablePunch", 1f);
        }
    }

    private void NothingPicked()
    {
        animator.SetBool("nothingFound2", false);
        animator.SetBool("isLeftHandUp2", false);
    }

    private void GrabObject()
    {
        if (grabbedObj != null)
        {
            FixedJoint fj = grabbedObj.AddComponent<FixedJoint>();
            fj.connectedBody = rb;
            fj.breakForce = 5000;
            alreadyGrabbing2 = true;
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
            alreadyGrabbing2 = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
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
        isPunching = false;
        animator.SetBool("isPunching", false);
    }

    private void EnablePunch()
    {
        canPunch = true;
    }
}
