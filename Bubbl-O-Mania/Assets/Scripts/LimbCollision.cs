using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbCollision : MonoBehaviour
{
  public PlayerController controller;
    void Start()
    {
        controller = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        controller.isGrounded = true;

    }
}
