using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageVisibility : MonoBehaviour
{
    public Image image1, image2, image3, image4;
    // Start is called before the first frame update
    void Start()
    {
        image1.enabled = false;
        image2.enabled = false;
        image3.enabled = false;
        image4.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Burada istediðiniz iþlemi gerçekleþtirebilirsiniz.
            Debug.Log("Space tuþuna basýldý!");


            if (image1.enabled == false)
            {
                image1.enabled=true;
            }
            else if (image2.enabled == false)
            {
                image2.enabled = true;
            }
            else if (image3.enabled == false)
            {
                image3.enabled = true;
            }
            else if (image4.enabled == false)
            {
                image4.enabled = true;
            }
        }
    }
}
