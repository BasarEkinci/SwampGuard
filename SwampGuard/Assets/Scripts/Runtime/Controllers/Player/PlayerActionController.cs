using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerActionController : MonoBehaviour
    {
        private Animator _animator;
        private bool _isShooting;
        private bool _isReloading;
        private bool _isAmmoFilled;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _isAmmoFilled = false;
            _isReloading = false;
        }

        private void Update()
        {
            _isShooting = InputManager.Instance.IsFireKeyPressed();
            _animator.SetBool("isShooting", _isShooting);
            _animator.SetBool("isAmmoFilled", _isAmmoFilled);
            if(!_isReloading && InputManager.Instance.IsReloadKeyPressed())
            {
                StartCoroutine(Reload());
            }

        }

        IEnumerator Reload()
        {
            _isAmmoFilled = false;
            _isReloading = true;
            _animator.SetBool("isReloading", _isReloading);
            _animator.SetBool("isAmmoFilled", _isAmmoFilled);
            yield return new WaitForSeconds(10);
            _isReloading = false;
            _isAmmoFilled = true;
            _animator.SetBool("isReloading", _isReloading);
            _animator.SetBool("isAmmoFilled", _isAmmoFilled);
            
        }
    }
}