using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 12f;
    private Vector2 playerInput;
    private Vector2 inputVector = new Vector2(0, 0);
    private CharacterController characterController;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = new Vector3(inputVector.x, 0, 0);
        playerInput = Vector2.ClampMagnitude(playerInput, 1);
        characterController.Move(playerInput * speed * Time.deltaTime);
    }

    public void Movement(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }
}
