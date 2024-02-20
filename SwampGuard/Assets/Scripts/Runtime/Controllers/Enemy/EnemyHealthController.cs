using Runtime.Data;
using UnityEngine;

namespace Runtime.Controllers.Enemy
{
    public class EnemyHealthController : MonoBehaviour
    {
        [SerializeField] private EnemyData enemyData;

        private int _currentHealth;

    
        private void OnEnable()
        {
            _currentHealth = enemyData.maxHealth;
        }

        internal void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}

