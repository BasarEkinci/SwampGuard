using System.Collections;
using Runtime.Data;
using UnityEngine;

namespace Runtime.COntrollers
{
    public class GunController : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private GunData gunData;

        [Header("Gun Settings")]
        [SerializeField] private Transform gunBarrel;
        [SerializeField] private float fireRange;

        private int _maxAmmo;
        private int _currentAmmo;
        private float _reloadTime;
        private int _damage;

        private void Start()
        {
            _maxAmmo = gunData.maxAmmo;
            _currentAmmo = _maxAmmo;
            _reloadTime = gunData.reloadTime;
            _damage = gunData.damage;
        }
        private void Shoot()
        {
            if(InputManager.Instance.IsFireKeyPressed())
            {
                if(_currentAmmo > 0)
                {   
                    RaycastHit hit;
                    if(Physics.Raycast(gunBarrel.position, gunBarrel.forward, out hit, fireRange))
                    {
                        Debug.Log(hit.transform.name);
                    }
                    _currentAmmo--;
                }
                else
                {
                    StartCoroutine(Reload());
                }
            }
            else if(InputManager.Instance.IsReloadKeyPressed())
            {
                StartCoroutine(Reload());
            }
        }

        private IEnumerator Reload()
        {
            while(_currentAmmo == _maxAmmo)
            {
                yield return new WaitForSeconds(_reloadTime);
                _currentAmmo++;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(gunBarrel.position, transform.forward * fireRange);
        }
    }
}