using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionController : MonoBehaviour
{
    private Animator _animator;
    private bool _isShooting;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isShooting = InputManager.Instance.IsFireKeyPressed();
        _animator.SetBool("isShooting", _isShooting);
        Debug.Log(_isShooting);
    }
}
