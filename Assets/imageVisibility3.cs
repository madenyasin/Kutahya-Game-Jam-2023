using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class imageVisibility3 : MonoBehaviour
{
    public Image[] images;
    public Button[] buttons;

    private int currentImageIndex = 1;

    void Start()
    {
        disableAllButtons();
        DisableAllImages();
        images[0].enabled = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentImageIndex == 2)
            {
                foreach (Button button in buttons)
                {
                    button.gameObject.SetActive(true);
                }
            }
            else if(currentImageIndex == 3) 
            {
                foreach (Button button in buttons)
                {
                    button.gameObject.SetActive(false);
                }
            }
            if (currentImageIndex < images.Length)
            {
                images[currentImageIndex].enabled = true;
                currentImageIndex++;
            }
            else
            {
                Debug.Log("T�m resimler g�r�n�r hale getirildi.");
                Invoke("changeScene", 5f);
            }
        }
    }

    public void DisableAllImages()
    {
        foreach (Image image in images)
        {
            image.enabled = false;
        }
    }
    public void disableAllButtons()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }


    public void path1()
    {
        
        disableAllButtons();
        DisableAllImages();
        Invoke("changeScene", 3f);

    }
    public void path2()
    {
        disableAllButtons();
        for (int i = 0; i < images.Length; i++)
        {
            if (i == 3)
            {
                images[i].enabled = true;
                continue;
            }
            images[i].enabled = false;

        }
        
        Invoke("changeScene", 5f);
    }
    public void path3()
    {
        
        disableAllButtons();
        DisableAllImages();
        Invoke("changeScene", 5f);

    }

    private void changeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
