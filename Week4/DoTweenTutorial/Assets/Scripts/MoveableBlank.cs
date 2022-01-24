using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableBlank : MonoBehaviour
{
    

    // Private variables for managing state of the moveable

    // Update is called once per frame
    void Update()
    {
        // Determine that we have a destination before continuing.
        

        // Ensure that the elapsed time of the lerp has not exceeded the total time allowed for the lerp.
        

        // Update the lerp duration and determine the percentage complete of the lerp.
        

        // Lerp the position of the object from the start position to the destination at the current percentage.
        

        // Call the on complete callback if we have reached the end of the total lerp duration.
        
    }

    public void MoveTo(Vector3 destination, Action onComplete = null)
    {
        // Set up the move controller to perform a move of the moveable to the new destination.
        
    }
}
