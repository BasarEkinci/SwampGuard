using Runtime.Controllers;
using UnityEngine;


namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        
        [Header("References")]
        [SerializeField] private PlayerMovementController movementController;
        [SerializeField] private PlayerRotationController rotationController;
        
        [Header("Movement Settings")]
        [SerializeField] private float moveSmoothTime;
        [SerializeField] private float gravityStrength;
        [SerializeField] private float jumpStrength;
        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;

        [Header("Rotation Settings")]
        [SerializeField] private Transform playerCamera;
        [SerializeField] private Vector2 sensitivies;


        private void Update()
        {
            movementController.MovePlayer(moveSmoothTime, gravityStrength, jumpStrength, walkSpeed, runSpeed);
            rotationController.Rotate(playerCamera,sensitivies);
        }

    }

}