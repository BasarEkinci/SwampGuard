using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        private CharacterController _controller;
        private Vector3 _currentMoveVelocity;
        private Vector3 _moveDampVelocity;
        private Vector3 _currentForceVelocity;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();
        }
        internal void MovePlayer(float moveSmoothTime, float gravityStrength, float jumpStrength, float walkSpeed, float runSpeed)
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
                _currentForceVelocity.y = -2f;

                if(InputManager.Instance.IsJumpKeyPressed())
                {
                    _currentForceVelocity.y = jumpStrength;
                }
            }
            else
            {
                _currentForceVelocity.y -= gravityStrength * Time.deltaTime;
            }

            _controller.Move(_currentForceVelocity * Time.deltaTime);
        }
    }
}
