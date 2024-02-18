using UnityEngine;

namespace Runtime.Data
{
    [CreateAssetMenu(fileName = "GunData", menuName = "SwampGuard/GunData", order = 0)]
    public class GunData : ScriptableObject
    {
        public int damage;
        public int maxAmmo;
        public float oneBulletReloadTime;
        public float fireRate;

    }
}