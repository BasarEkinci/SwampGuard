using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerRotationController : MonoBehaviour
    {
        private Vector2 _xyRotation;

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        internal void Rotate(Transform playerCamera,Vector2 sensitivities)
        {
            Vector2 input = InputManager.Instance.GetMousePosition();
            _xyRotation.x -= input.y * sensitivities.y * Time.deltaTime;
            _xyRotation.y += input.x * sensitivities.x * Time.deltaTime;

            _xyRotation.x = Mathf.Clamp(_xyRotation.x, -90f, 90f);

            transform.eulerAngles = new Vector3(0, _xyRotation.y, 0);
            playerCamera.localEulerAngles = new Vector3(_xyRotation.x, 0, 0);
        }
    }
}


