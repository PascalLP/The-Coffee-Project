using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointingArrow : MonoBehaviour
{
    public float floatSpeed = 1.0f; // Speed of floating
    public float floatHeight = 0.5f; // Height of the float
    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        // Calculate the new Y position using a sine wave
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        // Update the object's position
        transform.position = new Vector3(transform.position.x,newY, newY);
    }
}