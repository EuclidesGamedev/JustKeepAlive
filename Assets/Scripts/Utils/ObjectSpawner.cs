using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

namespace Utils
{
    public class ObjectSpawner : MonoBehaviour
    {
        private ObjectPool<PooledObject> _objectPool;
    
        [Header("Object Pool Settings")]
        [SerializeField] private PooledObject _objectToSpawn;
        [SerializeField] private bool _collectionCheck = true;
        [SerializeField] private int _defaultPoolSize = 10;
        [SerializeField] private int _maxPoolSize = 20;

        [Header("Spawner Settings")]
        [SerializeField] private bool _isSpawning = false;
        [SerializeField] private float _spawnInterval = .5f;
        [SerializeField] private Transform _objectContainer;
        private float _spawnTimer = 0f;
    
        #region MonoBehaviour
        private void Awake()
        {
            _objectPool = new ObjectPool<PooledObject>(
                CreatePooledObject, OnGetFromPool,
                OnReleaseToPool, OnDestroyPooledObject,
                _collectionCheck, _defaultPoolSize, _maxPoolSize
            );
        }

        private void Update()
        {
            UpdateSpawning();
        }
        #endregion
    
        #region ObjectPool Methods
        private PooledObject CreatePooledObject() { return Instantiate(_objectToSpawn); }
        private void OnReleaseToPool(PooledObject pooledObject) { pooledObject.gameObject.SetActive(false); }
        private void OnGetFromPool(PooledObject pooledObject) { pooledObject.gameObject.SetActive(true); }
        private void OnDestroyPooledObject(PooledObject pooledObject) { Destroy(pooledObject.gameObject); }
        #endregion
        
        #region Public Methods
        public void Activate() { _isSpawning = true; }
        public void Deactivate() { _isSpawning = false; }

        public void FullyDeactivate()
        {
            foreach (PooledObject pooledObject in _objectContainer.GetComponentsInChildren<PooledObject>())
                _objectPool.Release(pooledObject);
            _spawnTimer = 0;
            Deactivate();
        }

        public PooledObject GetProduct(Vector3 position)
        {
            PooledObject instance = _objectPool.Get();
            instance.ObjectPool = _objectPool;
            instance.transform.position = position;
            instance.transform.rotation = Quaternion.identity;
            instance.transform.SetParent(_objectContainer);
            return instance;
        }
        #endregion

        #region Spawner Methods

        private void UpdateSpawning()
        {
            if (!_isSpawning) return;
            
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer >= _spawnInterval)
            {
                GetProduct(new Vector3(Random.Range(-8.25f, 8.25f), 11f, 0));
                _spawnTimer = 0f;
            }
        }
        

        #endregion
    }
}
