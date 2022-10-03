<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterJump : MonoBehaviour
{
    private CharacterController characterController;

    private bool isGrounded = false;
    [SerializeField]
    private float jumpHeight = 5.0f;
    private bool jumpPressed = false;
    private bool isJumping = false;
    [SerializeField]
    private float jumpTime;
    private float jumpTimeCounter;


    [SerializeField]
    private float gravity = -9.81f;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    LayerMask groundLayer;
    private Vector3 velocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        if (isGrounded && velocity.y <= 0)
        {
            velocity.y = -2f;
        }

        if (jumpPressed)
        {
            if (isGrounded)
            {
                jumpTimeCounter = jumpTime;
                //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                velocity.y = jumpHeight;
            }
            jumpPressed = false;
        }

        if (isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                velocity.y = jumpHeight;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Jump");
            jumpPressed = true;
            isJumping = true;
        }
        if (context.canceled)
        {
            Debug.Log("Jump Cancelled");
            isJumping = false;
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterJump : MonoBehaviour
{
    private CharacterController characterController;

    private bool isGrounded = false;
    [SerializeField]
    private float jumpHeight = 5.0f;
    private bool jumpPressed = false;
    private bool isJumping = false;
    [SerializeField]
    private float jumpTime;
    private float jumpTimeCounter;


    [SerializeField]
    private float gravity = -9.81f;

    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    LayerMask groundLayer;
    private Vector3 velocity;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f, groundLayer);
        if (isGrounded && velocity.y <= 0)
        {
            velocity.y = -2f;
        }

        if (jumpPressed)
        {
            if (isGrounded)
            {
                jumpTimeCounter = jumpTime;
                //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                velocity.y = jumpHeight;
            }
            jumpPressed = false;
        }

        if (isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                velocity.y = jumpHeight;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Jump");
            jumpPressed = true;
            isJumping = true;
        }
        if (context.canceled)
        {
            Debug.Log("Jump Cancelled");
            isJumping = false;
        }
    }
}
>>>>>>> 53da11734e09d7081e62534f63a027d89746e7d2
