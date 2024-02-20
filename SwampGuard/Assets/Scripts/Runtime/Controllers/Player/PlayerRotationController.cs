using UnityEngine;

namespace Runtime.Controllers
{
    public class PlayerRotationController : MonoBehaviour
    {
        private Vector2 XYRotation;

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        internal void Rotate(Transform playerCamera,Vector2 sensivities)
        {
            Vector2 input = InputManager.Instance.GetMousePosition();
            XYRotation.x -= input.y * sensivities.y * Time.deltaTime;
            XYRotation.y += input.x * sensivities.x * Time.deltaTime;

            XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);

            transform.eulerAngles = new Vector3(0, XYRotation.y, 0);
            playerCamera.localEulerAngles = new Vector3(XYRotation.x, 0, 0);
        }
    }
}


