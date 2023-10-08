using UnityEngine;
using UnityEngine.UI;

public class CollapsibleImageToggle : MonoBehaviour
{
    public Image image; // Reference to the UI Image component
    private bool isImageVisible = false; // Flag to track image visibility

    void Start()
    {
        image.enabled = isImageVisible; // Set initial visibility state
    }

    void Update()
    {
        // Toggle image visibility when 'm' key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            isImageVisible = !isImageVisible;
            image.enabled = isImageVisible;
        }
    }
}
