using UnityEngine;

namespace Runtime.Data
{
    [CreateAssetMenu(fileName = "EnemyData", menuName = "SwampGuard/EnemyData", order = 0)]
    public class EnemyData : ScriptableObject
    {
        public int maxHealth;
        public float speed;
        public float attackRange;
        public float attackRate;
        public int damage;
    }
}