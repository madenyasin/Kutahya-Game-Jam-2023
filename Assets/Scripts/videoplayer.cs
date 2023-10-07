using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

using UnityEngine.SceneManagement;


public class videoplayer : MonoBehaviour
{
    VideoPlayer vp;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadNextScene", 3.1f);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
