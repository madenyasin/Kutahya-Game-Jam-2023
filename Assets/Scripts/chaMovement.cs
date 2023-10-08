using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chaMovement : MonoBehaviour
{
    private bool inputEnabled = true;
    private bool isGrounded = true;
    public float maxWalkSpeed;
    public float jumpSpeed;
    Vector3 playerVelocity;
    Rigidbody2D rb;
    Animator animator;
    public Camera camera;
    public Transform targetTransform;
    public float smoothSpeed = 0.5f;
    private Vector3 offset;
    private bool isCameraMoving = false;
    private Vector3 initialCameraPosition;

    private Vector3 respawnpoint;
    public GameObject FallDetector;

    public GameObject deathScreen;
    public Transform bolum2baslangic;


    void Start()
    {
        playerVelocity = Vector3.zero;
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        respawnpoint = transform.position;
    }

    
    void Update()
    {
    
       
       if(transform.position.x>146&&transform.position.x<150&&transform.position.y>-42f){
            SceneManager.LoadScene("Hikaye-4");
       } 
        if(transform.position.x>155&&transform.position.x<160&&transform.position.y<-42f){
            SceneManager.LoadScene("Hikaye-2");
        } 
        if (inputEnabled == true)
        {
            
            if (Input.GetAxis("Horizontal") > 0)
            {
                playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed;
                animator.Play("WalkingRight");
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed;
                animator.Play("WalkingLeft");
            }
            else
            {
                playerVelocity.x = 0;
                
                animator.Play("Idle");
                
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                playerVelocity.y = jumpSpeed;
                if (playerVelocity.x > 0) animator.Play("Jumping");
                else if (playerVelocity.x < 0) animator.Play("jumpingLeft");
                
                //inputEnabled = false;
            }
            else
            {
                playerVelocity.y = rb.velocity.y;
            }

            rb.velocity = playerVelocity;
        }
        Debug.Log("transform.position.x= "+transform.position.x);
        if(Input.GetKeyDown(KeyCode.E)&&transform.position.x>92.3f&&transform.position.x<94.8f){
            transform.position = bolum2baslangic.position;
            
        }else if(Input.GetKeyDown(KeyCode.E)&&transform.position.x>86f&&transform.position.x<89f){
            geber();
        }else if(Input.GetKeyDown(KeyCode.E)&&transform.position.x>96.8f&&transform.position.x<99.2f){
            geber();
        }

        FallDetector.transform.position = new Vector2(transform.position.x, FallDetector.transform.position.y);

        if(transform.position.x>30&&transform.position.x<35){
            inputEnabled = false;
             offset = camera.transform.position - targetTransform.position;
        initialCameraPosition = camera.transform.position;
        StartCoroutine(MoveCameraToTarget());
        
        Invoke("HikayePiramit",3f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
{

    if (collision.tag == "FallDetector")
    {
        deathScreen.SetActive(true);
        Invoke("yenidendog", 5f);

    }
    else if (collision.tag == "Checkpoint")
    {
        respawnpoint = transform.position;

    }
}

public void yenidendog()
 {

     transform.position = respawnpoint;
     deathScreen.SetActive(false);

 }
   
    IEnumerator MoveCameraToTarget()
    {
        isCameraMoving = true;
        camera.transform.SetParent(null);
        float elapsedTime = 0f;
        float moveDuration = 2f;

        while (elapsedTime < moveDuration)
        {
            camera.transform.position = Vector3.Lerp(initialCameraPosition, targetTransform.position, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        camera.transform.position = targetTransform.position;
        isCameraMoving = false;
        inputEnabled = true;
        camera.transform.SetParent(this.gameObject.transform);
        
    }
    void HikayePiramit(){
        SceneManager.LoadScene("Hikaye-Piramit");
    }
    
    void geber(){
        deathScreen.SetActive(true);
        Invoke("yenidendog", 5f);
    }
}
