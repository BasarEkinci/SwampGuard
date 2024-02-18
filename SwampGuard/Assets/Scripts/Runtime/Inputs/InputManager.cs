using Runtime.Extentions;
using UnityEngine;

public class InputManager : MonoSingelton<InputManager>
{
    private PlayerControls _playerControls;
    private void Awake()
    {
        SingeltonThisGameObject(this);
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    internal Vector2 GetMovementInput()
    {
        return _playerControls.Player.Movement.ReadValue<Vector2>();
    }

    internal Vector2 GetMousePosition()
    {
        return _playerControls.Player.Look.ReadValue<Vector2>();
    }

    internal bool IsJumpKeyPressed()
    {
        return _playerControls.Player.Jump.triggered;
    }

    internal bool IsRunKeyPressed()
    {
        return _playerControls.Player.SpeedUp.triggered;
    }

    internal bool IsFireKeyPressed()
    {
        return _playerControls.Player.Fire.triggered;
    }
    
    internal bool IsReloadKeyPressed()
    {
        return _playerControls.Player.Reload.triggered;
    }
}
