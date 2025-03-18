using UnityEngine;
using UnityEngine.Pool;

namespace Utils
{
    public abstract class PooledObject : MonoBehaviour
    {
        protected ObjectPool<PooledObject> __objectPool;
        public ObjectPool<PooledObject> ObjectPool
        {
            set => __objectPool = value;
        }
    }
}
