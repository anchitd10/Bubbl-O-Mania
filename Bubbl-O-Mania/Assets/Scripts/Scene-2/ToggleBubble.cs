using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ToggleBubble : MonoBehaviour
{
    public float reactivationDelay = 5f; // Time after which the GameObject will be reactivated

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Deactivate the GameObject
            gameObject.SetActive(false);

            // Reactivate the GameObject after a delay
            //StartCoroutine(ReactivateAfterDelay());
            
            ReactivateAfterDelay();
        }
    }
    /*
    private IEnumerator ReactivateAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(reactivationDelay);

        // Reactivate the GameObject
        gameObject.SetActive(true);
    }
    */

    async private void ReactivateAfterDelay()
    {
        // Wait for the specified delay (convert seconds to milliseconds)
        await Task.Delay((int)(reactivationDelay * 1000));

        // Unity-specific calls must run on the main thread
        if (this != null) // Check if the GameObject has not been destroyed
        {
            gameObject.SetActive(true);
        }
    }
}
