using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
// using UnityEditor.VersionControl;
using UnityEngine;

public class bubble_destroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bubble-Obstacle"))
        {
            Destroy(collision.gameObject);
        }
    }

}
