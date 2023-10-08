using UnityEngine;

public class WASDImageController : MonoBehaviour
{
    public GameObject wasdImage; // WASD resmi GameObject referans�

    private void Start()
    {
        // Ba�lang��ta resmin devre d��� oldu�undan emin ol
        wasdImage.SetActive(true);
    }

    private void Update()
    {
        // 10 saniye bekleyin (Update() fonksiyonunun bir karede bir kez �a�r�ld���n� varsayarsak)
        Invoke("HideWASDImage", 10f);
    }

    private void HideWASDImage()
    {
        // 10 saniye sonra resmi devre d��� b�rak
        wasdImage.SetActive(false);
    }
}
