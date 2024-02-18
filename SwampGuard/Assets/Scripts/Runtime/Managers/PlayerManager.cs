using UnityEngine;

namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private PlayerMovementController _movementController;

        [Header("Movement Settings")]
        [SerializeField] private float moveSmoothTime;
        [SerializeField] private float gravityStrength;
        [SerializeField] private float jumpStrenght;
        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;


        private void Update()
        {
            _movementController.MovePlayer(moveSmoothTime, gravityStrength, jumpStrenght, walkSpeed, runSpeed);
        }

    }

}