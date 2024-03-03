using DG.Tweening;
using UnityEngine;

namespace Runtime.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject hitCross;
        
        private void OnEnable()
        {
            Signals.PlayerSignals.Instance.OnHitEnemy += OnHitEnemy;
        }
        
        private void OnDisable()
        {
            Signals.PlayerSignals.Instance.OnHitEnemy -= OnHitEnemy;
        }

        private void OnHitEnemy()
        {
            hitCross.transform.DOScale(Vector3.one,0.02f).OnComplete(() =>
            {
                hitCross.transform.DOScale(Vector3.zero,0.2f);
            });
        }
    }
}