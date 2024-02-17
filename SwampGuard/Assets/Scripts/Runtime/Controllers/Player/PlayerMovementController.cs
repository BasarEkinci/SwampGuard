using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Transform orientation;

    private Vector3 _moveDirection;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _rb.freezeRotation = true;
    }
    private void Update()
    {
        GetMovementInput();
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    private Vector2 GetMovementInput()
    {
        return InputManager.Instance.GetMovementInput();
    }
    private void MovePlayer()
    {   
        _moveDirection = orientation.forward * GetMovementInput().y + orientation.right * GetMovementInput().x;
        _rb.AddForce(_moveDirection.normalized * moveSpeed * 10f, ForceMode.Acceleration);
    }

    private void RotatePlayer()
    {
        transform.rotation = orientation.rotation;
    }
}
