using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Add this using directive
using System;

public class trigger : MonoBehaviour
{
    public List<Button> buttons; // List of buttons to add hover detection to
    public Image image, image2, image3;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Start()
    {
        foreach (Button button in buttons)
        {
            // Add hover detection to each button in the list
            AddHoverDetectionToButton(button);
        }
        image.enabled = false;
        image2.enabled = false;
        image3.enabled = false;
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
        string name = button.gameObject.name;
        if (name == "Play")
        {
            image.enabled = true;
            image2.enabled = false;
            image3.enabled = false;
            playSound();
        }
        else if (name == "Quit")
        {
            image.enabled = false;
            image2.enabled = true;
            image3.enabled = false;
            playSound();
        }
        else
        {
            image.enabled = false;
            image2.enabled = false;
            image3.enabled = true;
            playSound();
        }
    }
    private void playSound() 
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
