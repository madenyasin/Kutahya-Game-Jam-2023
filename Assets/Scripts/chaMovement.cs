using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaMovement : MonoBehaviour
{
    private bool inputEnabled = true;
    private bool isJumping = false;
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
    void Start()
    {
        playerVelocity = Vector3.zero;
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {
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
                if (!isJumping)
                {
                    animator.Play("Idle");
                }
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                playerVelocity.y = jumpSpeed;
                if (playerVelocity.x > 0) animator.Play("Jumping");
                else if (playerVelocity.x < 0) animator.Play("jumpingLeft");
                isJumping = true;
                inputEnabled = false;
            }
            else
            {
                playerVelocity.y = rb.velocity.y;
            }

            rb.velocity = playerVelocity;
        }
        if(transform.position.x>30){
            inputEnabled = false;
             offset = camera.transform.position - targetTransform.position;
        initialCameraPosition = camera.transform.position;
        StartCoroutine(MoveCameraToTarget());
        }
    }

    public void OnJumpAnimationEnd()
    {
        isJumping = false;
        inputEnabled = true;
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

}