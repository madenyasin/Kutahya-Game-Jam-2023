using UnityEngine;

public class WASDImageController : MonoBehaviour
{
    public GameObject wasdImage; // WASD resmi GameObject referansý

    private void Start()
    {
        // Baþlangýçta resmin devre dýþý olduðundan emin ol
        wasdImage.SetActive(true);
    }

    private void Update()
    {
        // 10 saniye bekleyin (Update() fonksiyonunun bir karede bir kez çaðrýldýðýný varsayarsak)
        Invoke("HideWASDImage", 10f);
    }

    private void HideWASDImage()
    {
        // 10 saniye sonra resmi devre dýþý býrak
        wasdImage.SetActive(false);
    }
}
