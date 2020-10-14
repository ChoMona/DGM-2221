using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Jumps : MonoBehaviour
{
    public CharacterController controller;

    public float jumpForce = 2f, gravity = -5f;
    
    private Vector3 movement;
    
    private float yVar;
    
    public IntData jumpCount, maxJumpCount;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    
    void Update()
    {
        //setting up Gravity
        yVar += gravity * Time.deltaTime;

        //So Gravity doesnt add onto itself
        if (controller.isGrounded && movement.y < 0)
        {
            yVar = -1f;
            jumpCount.value = 0;
        }

        //Jump and Double Jump
        if (Input.GetButtonDown("Jump"))

        {
            if (jumpCount.value < maxJumpCount.value)
            {
                yVar = jumpForce;
                jumpCount.value++;
            }
        }

        movement.y = yVar;
        controller.Move(movement);
    }
}
