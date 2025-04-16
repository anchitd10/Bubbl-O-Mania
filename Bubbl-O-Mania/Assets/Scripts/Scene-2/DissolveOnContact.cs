using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveOnContact : MonoBehaviour
{
    public Material dissolveMaterial; // Assign your custom shader material here
    public string dissolveProperty = "Disolve"; // Name of the dissolve property in the shader
    public float dissolveSpeed = 1f; // Speed at which the dissolve happens

    private bool isDissolving = false; // Flag to track if the dissolve process has started
    private float dissolveValue = 0f; // Current value of dissolve

    private void Start()
    {
        // Ensure the dissolve material is assigned
        if (dissolveMaterial == null)
        {
            Debug.LogError("Dissolve material is not assigned.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with the object
        if (other.CompareTag("Player") && !isDissolving)
        {
            isDissolving = true;
        }
    }

    private void Update()
    {
        if (isDissolving)
        {
            // Increase the dissolve value over time
            dissolveValue += Time.deltaTime * dissolveSpeed;
            dissolveMaterial.SetFloat(dissolveProperty, dissolveValue);

            // Check if dissolve is complete
            if (dissolveValue >= 1f)
            {
                dissolveValue = 1f; // Clamp the value to 1
                isDissolving = false;

                // Deactivate the GameObject
                gameObject.SetActive(false);
            }
        }
    }
}

