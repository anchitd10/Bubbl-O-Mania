using UnityEngine;

public class BubbleJiggle : MonoBehaviour
{
    public float jiggleIntensity = 0.1f; // How much the bubble scales
    public float jiggleSpeed = 5f;      // How fast the jiggle happens

    private Vector3 initialScale;

    void Start()
    {
        // Store the initial scale of the bubble
        initialScale = transform.localScale;
    }

    void Update()
    {
        // Apply a sinusoidal scaling effect for the jiggle
        float scaleX = initialScale.x + Mathf.Sin(Time.time * jiggleSpeed) * jiggleIntensity;
        float scaleY = initialScale.y + Mathf.Cos(Time.time * jiggleSpeed) * jiggleIntensity;
        float scaleZ = initialScale.z + Mathf.Sin(Time.time * jiggleSpeed) * jiggleIntensity;

        // Update the bubble's scale
        transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
    }
}