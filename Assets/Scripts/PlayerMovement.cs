using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 7f;
    public float gravity = -25f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public LayerMask groundMask;

    Vector3 velocity;

    bool isGrounded;
    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("LeftShift") && isGrounded)
        {
            speed = 12f;
        }

        if (Input.GetButtonUp("LeftShift") && isGrounded)
        {
            speed = 7f;
        }

        if (Input.GetButtonDown("crtl") && isGrounded)
        {
            speed = 3f;
        }

        if (Input.GetButtonUp("crtl") && isGrounded)
        {
            speed = 7f;
        }
    }
}
