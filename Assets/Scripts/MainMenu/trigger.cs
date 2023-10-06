using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Add this using directive

public class trigger : MonoBehaviour
{
    public List<Button> buttons; // List of buttons to add hover detection to

    private void Start()
    {
        foreach (Button button in buttons)
        {
            // Add hover detection to each button in the list
            AddHoverDetectionToButton(button);
        }
    }

    private void AddHoverDetectionToButton(Button button)
    {
        // Add a pointer enter event using EventTrigger to the specified button
        EventTrigger trigger = button.gameObject.GetComponent<EventTrigger>();
        if (trigger == null)
        {
            // If there's no EventTrigger, add one
            trigger = button.gameObject.AddComponent<EventTrigger>();
        }

        // Create an entry for the pointer enter event
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter; // Trigger on mouse hover

        // Add a callback to the entry
        entry.callback.AddListener((data) => { HandlePointerEnter(button); });

        // Add the entry to the EventTrigger
        trigger.triggers.Add(entry);
    }

    private void HandlePointerEnter(Button button)
    {
        // Print the button's name to the console
        Debug.Log("Button Hovered: " + button.gameObject.name);
    }
}
