using Runtime.Data;
using Runtime.Managers;
using TMPro;
using UnityEngine;
using Cysharp.Threading.Tasks;
using Runtime.Controllers.Enemy;

namespace Runtime.Controllers.Gun
{
    public class GunController : MonoBehaviour
    {

        #region Editor Properties
        [Header("References")]
        [SerializeField] private GunData gunData;
        [SerializeField] private TMP_Text ammoText;
        [SerializeField] private ParticleSystem muzzleFlash;
        [SerializeField] private ParticleSystem hitEffect;

        [Header("Gun Settings")]
        [SerializeField] private Transform gunBarrel;

        [SerializeField] private float fireRange;
        [SerializeField] private LayerMask layerMask;
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
            _fireRate = gunData.fireRate;
            _isShooting = false;
        }
        private void Update()
        {
            ammoText.text = $"{_currentAmmo}/{_maxAmmo}";
            
            if(InputManager.Instance.IsFireKeyPressed())
                Shoot();
            if(InputManager.Instance.IsReloadKeyPressed())
                Reload();
        }

        private async void Shoot()
        {
            if(_isReloading || _isShooting) return;
            if(_currentAmmo >= 1)
            {
                _isShooting = true;
                _animator.SetBool(IsShooting, true);
                muzzleFlash.Play();
                DetectEnemy();
                SoundManager.Instance.PlayOneShot((int)GunSoundEffectsEnum.ShotSound);
                _currentAmmo--;
                await UniTask.Delay(_fireRate);
                _animator.SetBool(IsShooting, false);
                _isShooting = false;
            }
            else
            {
                SoundManager.Instance.PlayOneShot((int)GunSoundEffectsEnum.EmptyShotSound);
            }
        }

        private async void Reload()
        {
            if(_currentAmmo >= _maxAmmo || _isReloading || _isShooting) return;
            while (_currentAmmo != _maxAmmo)
            {
                _isReloading = true;
                _animator.SetBool(IsReloading, true);
                await UniTask.Delay(_oneBulletReloadTime); 
                SoundManager.Instance.PlayOneShot((int)GunSoundEffectsEnum.ReloadSound);
                _currentAmmo++;
            }
            SoundManager.Instance.PlayOneShot((int)GunSoundEffectsEnum.LoadSound);
            _animator.SetBool(IsReloading, false);
            _isReloading = false;
        }
        
        private void DetectEnemy()
        {
            Ray ray = new Ray(gunBarrel.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, fireRange, layerMask))
            {
                Debug.Log(hit.transform.name);
                hitEffect.transform.position = hit.point;
                hitEffect.Play();
                if (hit.transform.TryGetComponent(out EnemyHealthController damageable))
                {
                    Instantiate(hitEffect, hit.point, hit.transform.rotation);
                    damageable.TakeDamage(_damage);
                }
            }
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(gunBarrel.position, transform.forward * fireRange);
        }
    }
}