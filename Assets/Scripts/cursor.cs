using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockCursorOnLoad : MonoBehaviour
{
    void Start()
    {
        // Unlock the cursor when the scene is loaded
        UnlockCursor();
    }

    void UnlockCursor()
    {
        // Set the cursor to be visible and not locked to the center of the screen
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        Cursor.visible = true;                   // Make the cursor visible
    }
}