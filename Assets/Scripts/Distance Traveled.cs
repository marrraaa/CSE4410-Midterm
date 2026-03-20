using System.Collections;   
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DistanceTraveled : MonoBehaviour
{
    // Public variable to display the distance traveled in the UI
    public TextMeshProUGUI distanceText;

    // Private variables to track the starting position and total distance traveled
    private Vector3 startPosition;
    private float distanceTraveled = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the starting position and distance traveled
        startPosition = transform.position;
        UpdateDistanceText();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the distance traveled in this frame and add it to the total distance
        float distanceInFrame = Vector3.Distance(transform.position, startPosition);
        distanceTraveled += distanceInFrame;
        startPosition = transform.position;

        // Update the distance text with the current distance traveled
        UpdateDistanceText();
    }
        void UpdateDistanceText()
    {
        // Update the distance text with the current distance traveled, formatted to round to nearest integer
           distanceText.text = "Distance Traveled: " + Mathf.Round(distanceTraveled).ToString();
    }
}   
        
    

