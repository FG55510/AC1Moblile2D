using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirculodeInfluenciadoPlayer : MonoBehaviour
{
    public GameObject circlePrefab; // The circle GameObject to instantiate
    public float growthSpeed = 2f;  // Speed at which the circle grows
    public float maxSize = 3f;     // Maximum scale of the circle
    public float minSize = 0.1f;   // Minimum scale of the circle

    private GameObject currentCircle;
    private bool isPressing = false;
    private Vector2 pressPosition;

    void Update()
    {
        // Detecting long press using mouse or touch input
        if (Input.GetMouseButton(0)) // For touch or mouse press
        {
            if (!isPressing)
            {
                // Start press, instantiate a new circle at the press position
                isPressing = true;
                pressPosition = Input.mousePosition;

                // Convert screen position to world position
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(pressPosition.x, pressPosition.y, Camera.main.nearClipPlane));
                worldPosition.z = 0f; // Ensure the circle is on the correct plane (2D)

                currentCircle = Instantiate(circlePrefab, worldPosition, Quaternion.identity); // Create circle at touch position
                currentCircle.transform.localScale = new Vector3(minSize, minSize, 1); // Initial scale of the circle
            }
            else
            {
                // Grow the circle
                float size = Mathf.Min(currentCircle.transform.localScale.x + growthSpeed * Time.deltaTime, maxSize);
                currentCircle.transform.localScale = new Vector3(size, size, 1);
            }
        }
        else
        {
            if (isPressing)
            {
                // Reset circle when press ends
                isPressing = false;
                Destroy(currentCircle); // Destroy the current circle when the press ends
            }
        }
    }
}
