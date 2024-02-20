using Runtime.Controllers.Enemy;
using Runtime.Data;
using Runtime.Managers;
using TMPro;
using System.Collections;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Runtime.Controllers.Gun
{
    public class GunController : MonoBehaviour
    {

        #region Editor Properties
        [Header("References")]
        [SerializeField] private GunData gunData;
        [SerializeField] private TMP_Text ammoText;
        [SerializeField] private ParticleSystem muzzleFlash;

        [Header("Gun Settings")]
        [SerializeField] private Transform gunBarrel;

        [SerializeField] private float fireRange;
        [SerializeField] private LayerMask layer;
        #endregion

        #region Private Properties
        private Animator _animator;
        //Gun Values
        private int _maxAmmo;
        private int _currentAmmo;
        private int _oneBulletReloadTime;
        private int _damage;
        private int _fireRate;
        private bool _isShooting;
        private bool _isReloading;
        
        //Animation Hashes
        private static readonly int IsShooting = Animator.StringToHash("isShooting");
        private static readonly int IsReloading = Animator.StringToHash("isReloading");

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
            _fireRate = (int)gunData.fireRate;
            _isShooting = false;
        }
        private void Update()
        {
            ammoText.text = $"{_currentAmmo}/{_maxAmmo}";
            
            if (InputManager.Instance.IsFireKeyPressed())
                Shoot();
            if(InputManager.Instance.IsReloadKeyPressed())
                Reload();
        }

        private async void Shoot()
        {
            if(_currentAmmo <= 0 || _isReloading || _isShooting) return;
            _isShooting = true;
            _animator.SetBool(IsShooting, true);
            muzzleFlash.Play();
            SoundManager.Instance.PlayOneShot(0);
            _currentAmmo--;
            await UniTask.Delay(_fireRate);
            _animator.SetBool(IsShooting, false);
            _isShooting = false;
        }

        private async void Reload()
        {
            if(_currentAmmo >= _maxAmmo || _isReloading || _isShooting) return;
            while (_currentAmmo != _maxAmmo)
            {
                _isReloading = true;
                _animator.SetBool(IsReloading, true);
                await UniTask.Delay(_oneBulletReloadTime); 
                SoundManager.Instance.PlayOneShot(1);
                _currentAmmo++;
            }
            _isReloading = false;
            SoundManager.Instance.PlayOneShot(2);
            _animator.SetBool(IsReloading, false);
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(gunBarrel.position, transform.forward * fireRange);
        }
    }
}