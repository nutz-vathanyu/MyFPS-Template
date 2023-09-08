using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionScript : MonoBehaviour
{
    private void Start()
    {
        // Find the GameObject with the ActionInput script


        // Get the ActionInput component from that GameObject
        ActionInput actionInput = this.GetComponent<ActionInput>();

        // Subscribe to the custom event using +=
        actionInput.onAction += StartAction;
    }

    // This method will be called when the event is triggered
    private void StartAction()
    {
        Debug.Log("ActionScript: Event received, starting action");
        // Perform your desired action here
    }

}
