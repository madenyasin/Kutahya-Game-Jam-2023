using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaMovement : MonoBehaviour
{
    
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

void Update() {
    playerVelocity.x = Input.GetAxis("Horizontal") * maxWalkSpeed;
    animator.Play("WalkingRight");
    if (Input.GetKeyDown(KeyCode.Space)) {
        playerVelocity.y = jumpSpeed;
    } else {
        playerVelocity.y = rb.velocity.y;
    }
    rb.velocity = playerVelocity;

}

}
