using System.Collections;
using Runtime.Data;
using TMPro;
using UnityEngine;

namespace Runtime.COntrollers
{
    public class GunController : MonoBehaviour
    {

#region Editor Properties
        [Header("References")]
        [SerializeField] private GunData gunData;
        [SerializeField] private TMP_Text ammoText;

        [Header("Gun Settings")]
        [SerializeField] private Transform gunBarrel;
        [SerializeField] private float fireRange;
#endregion

#region Private Properties
        private Animator _animator;
        //Gun Values
        private int _maxAmmo;
        private int _currentAmmo;
        private float _oneBulletReloadTime;
        private int _damage;
        private float _fireRate;

        private bool _isShooting;

        
#endregion
        private void Awake()
        {
            _animator = GetComponent<Animator>();

        }

        private void Start()
        {
            _maxAmmo = gunData.maxAmmo;
            _currentAmmo = _maxAmmo;
            _oneBulletReloadTime = gunData.oneBulletReloadTime;
            _damage = gunData.damage;
            _fireRate = gunData.fireRate;
            _isShooting = false;
        }
        private void Update()
        {
            ammoText.text = $"{_currentAmmo}/{_maxAmmo}";
            if(!_isShooting && InputManager.Instance.IsFireKeyPressed())
            {
                _isShooting = true;
                Shoot();
            }
            if(InputManager.Instance.IsReloadKeyPressed())
            {
                Reload();
            }
            Debug.Log($"{_currentAmmo}/{_maxAmmo}");
        }

        private void Shoot()
        {
            
            if(_currentAmmo > 0)
            {   

                RaycastHit hit;
                if(Physics.Raycast(gunBarrel.position, gunBarrel.forward, out hit, fireRange))
                {
                    Debug.Log(hit.transform.name);
                }
                StartCoroutine(FireRate());
            }
            else
            {
                StartCoroutine(ReloadCoroutine());
                _isShooting = false;
            }
        }

        private void Reload()
        {
            if(_currentAmmo < _maxAmmo)
            {
                StartCoroutine(ReloadCoroutine());
            }
        }

        private IEnumerator FireRate()
        {
            _animator.SetBool("isShooting", true);
            yield return new WaitForSeconds(_fireRate);
            _isShooting = false;
            _currentAmmo--;
            _animator.SetBool("isShooting", false);
        }
        private IEnumerator ReloadCoroutine()
        {
            _animator.SetBool("isReloading", true);
            while(_currentAmmo != _maxAmmo)
            {
                yield return new WaitForSeconds(_oneBulletReloadTime);
                _currentAmmo++;
            }
            _animator.SetBool("isReloading", false);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(gunBarrel.position, transform.forward * fireRange);
        }
    }
}