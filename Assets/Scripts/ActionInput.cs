using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionInput : MonoBehaviour
{
    // Declare an Action event
    public event System.Action onAction;

    // Example method that triggers the event
    public void PerformAction()
    {
        Debug.Log("ActionInput: Performing action");
        onAction?.Invoke(); // Trigger the event if it's not null
    }

}
