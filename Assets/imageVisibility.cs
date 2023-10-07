using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageVisibility : MonoBehaviour
{
    public Image[] images;

    private int currentImageIndex = 1;

    void Start()
    {
        DisableAllImages();
        images[0].enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (currentImageIndex < images.Length)
            {
                images[currentImageIndex].enabled = true;
                currentImageIndex++;
            }
            else
            {
                Debug.Log("Tüm resimler görünür hale getirildi.");
            }
        }
    }

    void DisableAllImages()
    {
        foreach (Image image in images)
        {
            image.enabled = false;
        }
    }
}
