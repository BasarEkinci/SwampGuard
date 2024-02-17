using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Controllers.Player
{
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
        }
    }
}