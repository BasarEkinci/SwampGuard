using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCamController : MonoBehaviour
{
    [SerializeField] private float sensX = 400f;
    [SerializeField] private float sensY = 400f;
    [SerializeField] private Transform _orientation;

    
    private float _rotationX;
    private float _rotationY;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Vector2 input = InputManager.Instance.GetMousePosition();
        _rotationY += input.x * sensX * Time.deltaTime;
        _rotationX -= input.y * sensY * Time.deltaTime;

        _rotationX = Mathf.Clamp(_rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(_rotationX, _rotationY, 0);
        _orientation.rotation = Quaternion.Euler(0, _rotationY, 0);
    }
}
