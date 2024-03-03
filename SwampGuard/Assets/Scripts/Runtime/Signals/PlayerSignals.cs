using Runtime.Extentions;
using UnityEngine.Events;

namespace Runtime.Signals
{
    public class PlayerSignals : MonoSingelton<PlayerSignals>
    {
        private void Awake()
        {
            SingeltonThisGameObject(this);
        }

        public UnityAction OnHitEnemy = delegate { };
    }
}