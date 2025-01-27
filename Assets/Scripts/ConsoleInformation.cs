using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public Canvas infoCanvas;  // Assign the canvas in the inspector
    private bool isNearObject = false;  // Tracks if the player is near the object
    private bool isCanvasOpen = false;  // Tracks if the canvas is open

    void Update()
    {
        // If the player is near the object and presses 'E' when the canvas is open
        if (isNearObject && Input.GetKeyDown(KeyCode.E) && isCanvasOpen)
        {
            CloseCanvas();  // Close the canvas and resume the game
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If the player enters the trigger collider, show the canvas automatically
        if (other.CompareTag("Player"))
        {
            isNearObject = true;
            OpenCanvas();  // Open the canvas as soon as the player is near
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If the player leaves the trigger collider, reset the state (optional)
        if (other.CompareTag("Player"))
        {
            isNearObject = false;
        }
    }

    private void OpenCanvas()
    {
        // Open the canvas and pause the game
        if (!isCanvasOpen)
        {
            infoCanvas.gameObject.SetActive(true);  // Show the canvas
            isCanvasOpen = true;
            Time.timeScale = 0;  // Pause the game by setting time scale to 0
        }
    }

    private void CloseCanvas()
    {
        // Close the canvas and resume the game
        if (isCanvasOpen)
        {
            infoCanvas.gameObject.SetActive(false);  // Hide the canvas
            isCanvasOpen = false;
            Time.timeScale = 1;  // Resume the game by setting time scale back to 1
        }
    }
}