using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleGravity : MonoBehaviour
{
    public float gravity = -9.81f; // Adjust the gravity force as needed
    public float fallSpeed = 0.0f; // Initial falling speed

    private void Update()
    {
        // Calculate the object's new position based on gravity
        Vector3 newPosition = transform.position;
        fallSpeed += gravity * Time.deltaTime;
        newPosition.y += fallSpeed * Time.deltaTime;
        transform.position = newPosition;

        // Check if the object is below the ground, reset its position to prevent falling indefinitely
        if (newPosition.y < -10f) // Change this value to your ground level
        {
            newPosition.y = 0f; // Reset the Y position to prevent falling through the ground
            fallSpeed = 0f; // Reset the falling speed
            transform.position = newPosition;
        }
    }
}
