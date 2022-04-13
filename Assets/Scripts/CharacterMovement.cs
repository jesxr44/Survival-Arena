using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed;
    private float gravity = -9.81f;
    [SerializeField]
    private float jumpSpeed = 12f;
    private float directionY;

    private Vector2 playerInput;
    private Vector2 inputVector = new Vector2(0, 0);
    private CharacterController characterController;
    private bool jumpPressed = false;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerInput = new Vector3(inputVector.x, 0, 0);
        playerInput = Vector2.ClampMagnitude(playerInput, 1);

        if (jumpPressed)
        {
          if (characterController.isGrounded)
          {
              directionY = Mathf.Sqrt(jumpSpeed * gravity * -1f);
          }
            jumpPressed = false;
        }

        directionY += gravity * Time.deltaTime;
        playerInput.y = directionY;

        characterController.Move(playerInput * playerSpeed * Time.deltaTime);
    }

    public void Movement(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Jump");
            jumpPressed = true;
        }
    }
}
