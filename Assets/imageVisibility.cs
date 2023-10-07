using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class imageVisibility : MonoBehaviour
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
            if(currentImageIndex == 3) {
                foreach (Button button in buttons)
                {
                    button.gameObject.SetActive(true);
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
        for (int i = 0; i < images.Length; i++) 
        {
            if (i == 4)
            {
                images[i].enabled = true;
                continue;
            }
            images[i].enabled = false;

        }
        disableAllButtons();
        Invoke("changeScene", 3f);
        
    }
    public void path2()
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (i == 5)
            {
                images[i].enabled = true;
                continue;
            }
            images[i].enabled = false;

        }
        disableAllButtons();
        Invoke("changeScene", 5f);
    }
    public void path3()
    {
        for (int i = 0; i < images.Length; i++)
        {
            if (i == 6)
            {
                images[i].enabled = true;
                continue;
            }
            images[i].enabled = false;

        }
        disableAllButtons();
        Invoke("changeScene", 5f);

    }

    private void changeScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
