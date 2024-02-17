using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] private float moveSmoothTime;
    [SerializeField] private float gravityStrength;
    [SerializeField] private float jumpStrenght;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private CharacterController _controller;
    private Vector3 _currentMoveVelocity;
    private Vector3 _moveDampVelocity;
    private Vector3 currentForceVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector2 input = InputManager.Instance.GetMovementInput();

        Vector3 playerInput = new Vector3(input.x, 0, input.y);

        if(playerInput.magnitude > 1f)
        {
            playerInput.Normalize();
        }

        Vector3 moveVector = transform.TransformDirection(playerInput);
        float currentSpeed = InputManager.Instance.IsRunKeyPressed() ? runSpeed : walkSpeed;

        _currentMoveVelocity = Vector3.SmoothDamp(
            _currentMoveVelocity,
            moveVector * currentSpeed,
            ref _moveDampVelocity,
            moveSmoothTime
        );

        _controller.Move(_currentMoveVelocity * Time.deltaTime);

        Ray groundChechkRay = new Ray(transform.position, Vector3.down);
        if(Physics.Raycast(groundChechkRay, 1.1f))
        {
            currentForceVelocity.y = -2f;

            if(InputManager.Instance.IsJumpKeyPressed())
            {
                currentForceVelocity.y = jumpStrenght;
            }
        }
        else
        {
            currentForceVelocity.y -= gravityStrength * Time.deltaTime;
        }

        _controller.Move(currentForceVelocity * Time.deltaTime);
    }
}
