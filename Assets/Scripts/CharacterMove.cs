<<<<<<< HEAD
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class CharacterMove : MonoBehaviour
{
    private const string IsRunning = "isRunning";

    private CharacterController characterController;
    private Animator animator;

    private Vector2 currentMovementInput;
    private Vector3 currentMovement;
    private bool isMovementPressed;

    // Constants
    [SerializeField]
    private float rotationFactorPerFrame = 1.0f;
    [SerializeField]
    float runMultiplier = 3.0f;
    bool isJumpPressed = false;

    int isRunningHash;

    //gravity variables
    float gravity = -9.8f;
    float groundedGravity = -0.5f;

    // jumpint variables
    float initialJumpVelocity;
    float maxJumpHeight = 1.0f;
    float maxJumpTime = 0.5f;
    bool isJumping = false;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash(IsRunning);

        setupJumpVariables();
    }

    // Update is called once per frame
    void Update()
    { 
        HandleRotation();
        HandleAnimation();
        characterController.Move(currentMovement * Time.deltaTime);
        HandleGravity();
        HandleJump();
    }
    void setupJumpVariables()
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    }

    void HandleGravity()
    {
        if (characterController.isGrounded)
        {
            currentMovement.y = groundedGravity;
        }
        else
        {
            currentMovement.y += gravity * Time.deltaTime;
        }
    }

    void HandleAnimation()
    {
        bool isRunning = animator.GetBool(isRunningHash);

        if (isMovementPressed && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if (!isMovementPressed && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    void HandleRotation()
    {
        Vector3 positionToLookAt = new Vector3();
        positionToLookAt.x = currentMovement.x;

        Quaternion currentRotation = transform.rotation;
        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }

    }

    void HandleJump()
    {
        if (!isJumping && characterController.isGrounded && isJumpPressed)
        {
            isJumping = true;
            currentMovement.y = initialJumpVelocity;
        } else if (!isJumpPressed && isJumping && characterController.isGrounded)
        {
            isJumping = false;
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement = new Vector3(currentMovementInput.x * runMultiplier, 0, 0);
        isMovementPressed = currentMovement.x != 0;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.ReadValueAsButton();
        Debug.Log(isJumpPressed);
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class CharacterMove : MonoBehaviour
{
    private const string IsRunning = "isRunning";

    private CharacterController characterController;
    private Animator animator;

    private Vector2 currentMovementInput;
    private Vector3 currentMovement;
    private bool isMovementPressed;

    [SerializeField]
    private float rotationFactorPerFrame = 1.0f;
    [SerializeField]
    float runMultiplier = 3.0f;

    int isRunningHash;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isRunningHash = Animator.StringToHash(IsRunning);
    }

    // Update is called once per frame
    void Update()
    {
        HandleGravity();
        HandleRotation();
        HandleAnimation();
        characterController.Move(currentMovement * Time.deltaTime);
    }

    void HandleGravity()
    {
        if (characterController.isGrounded)
        {
            float groundedGravity = -0.05f;
            currentMovement.y = groundedGravity;
        }
        else
        {
            currentMovement.y += Physics.gravity.y;
        }
    }

    void HandleAnimation()
    {
        bool isRunning = animator.GetBool(isRunningHash);

        if (isMovementPressed && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if (!isMovementPressed && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    void HandleRotation()
    {
        Vector3 positionToLookAt = new Vector3();
        positionToLookAt.x = currentMovement.x;

        Quaternion currentRotation = transform.rotation;
        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }

    }

    public void Movement(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement = new Vector3(currentMovementInput.x * runMultiplier, 0, 0);
        isMovementPressed = currentMovement.x != 0;
    }
}
>>>>>>> 53da11734e09d7081e62534f63a027d89746e7d2
