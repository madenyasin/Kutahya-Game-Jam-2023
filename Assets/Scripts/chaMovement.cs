using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaMovement : MonoBehaviour
{
    private bool inputEnabled = true;
    private bool isJumping = false; // jumping animasyonunun oynadığını takip etmek için bir değişken
    public float maxWalkSpeed;
    public float jumpSpeed;
    Vector3 playerVelocity;
    Rigidbody2D rb;
    Animator animator;
    

void Start() {
    playerVelocity = Vector3.zero;
    rb = this.GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    
}



void Update()
{
    
    if(inputEnabled==true){
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
                playerVelocity.x = 0; // Hareketsizlik durumunda x hızını sıfırla
                if (!isJumping) // jumping animasyonu oynanmıyorsa Idle animasyonunu oynat
                {
                    animator.Play("Idle");
                }
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerVelocity.y = jumpSpeed;
                if(playerVelocity.x>0)animator.Play("Jumping");
                else if(playerVelocity.x<0)animator.Play("jumpingLeft");
                isJumping = true;
                inputEnabled=false; // jumping animasyonunun oynadığını işaretle
            }
            else
            {
                playerVelocity.y = rb.velocity.y;
            }

            rb.velocity = playerVelocity;
            }
    
}

// Jumping animasyonunun bitişinde çağrılacak olan bir fonksiyon

public void OnJumpAnimationEnd()
{
    isJumping = false;
    inputEnabled = true;
    
}



}
