using UnityEngine;

namespace Runtime.Controllers
{
    public class PlayerRotationController : MonoBehaviour
    {
        [SerializeField] private Transform playerCamera;
        [SerializeField] private Vector2 sensitivies;

        private Vector2 XYRotation;

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        private void Update()
        {
            Vector2 input = InputManager.Instance.GetMousePosition();
            XYRotation.x -= input.y * sensitivies.y * Time.deltaTime;
            XYRotation.y += input.x * sensitivies.x * Time.deltaTime;

            XYRotation.x = Mathf.Clamp(XYRotation.x, -90f, 90f);

            transform.eulerAngles = new Vector3(0, XYRotation.y, 0);
            playerCamera.localEulerAngles = new Vector3(XYRotation.x, 0, 0);
        }
    }
}


