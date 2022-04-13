using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterJump : MonoBehaviour
{
    private CharacterController characterController;

    private Vector2 playerVelocity;
    private bool isGrounded = false;
    private float jumpHeight = 5.0f;
    private bool jumpPressed = false;
    private float gravity = -9.81f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update() {
        //MovementJump();
    }

    private void MovementJump()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded)
        {
            playerVelocity.y = 0.0f;
        }

        if (jumpPressed && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * gravity * -1.0f);
            jumpPressed = false;
        }

        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (characterController.velocity.y == 0)
        {
            Debug.Log("Can jump");
            jumpPressed = true;
        }
        else
        {
            Debug.Log("Can't jump");
        }
    }
}
