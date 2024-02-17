using UnityEngine;
using Cinemachine;

namespace Runtime.Extentions
{
    public class CinemachinePOVExtention : CinemachineExtension
    {
        [SerializeField] private float horizontalSpeed = 10.0f;
        [SerializeField] private float verticalSpeed = 10.0f;
        [SerializeField] private float clampAngle = 80.0f;

        private InputManager _inputManager;
        private Vector3 startingRotation;

        protected override void Awake()
        {
            _inputManager = InputManager.Instance;
            startingRotation = transform.localRotation.eulerAngles;
            base.Awake();
        }

        protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if(vcam.Follow)
            {
                if(stage == CinemachineCore.Stage.Aim){
                    Vector2 deltaInput = _inputManager.GetMousePosition();
                    startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
                    startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
                    startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                    state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
                }   
            }
        }
    }
}

