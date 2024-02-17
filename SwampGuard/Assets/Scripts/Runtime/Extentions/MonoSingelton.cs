using UnityEngine;

namespace Runtime.Extentions
{
    public abstract class MonoSingelton<T> : MonoBehaviour
    {
        public static T Instance { get; private set; }

        protected void SingeltonThisGameObject(T entity)
        {
            if (Instance == null)
            {
                Instance = entity;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}