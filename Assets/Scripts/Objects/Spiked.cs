using Game.Managers;
using Player;
using UnityEngine;
using Utils;

namespace Objects
{
    public class Spiked : PooledObject
    {
        private Rigidbody2D rb;
        private bool _isSpiked = false;
        private float _spikeTime;
        private float _timer;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        
        private void Start()
        {
            _timer = _spikeTime = Random.Range(3f, 7f);
        }
        
        private void Update()
        {
            if (!_isSpiked) return;
            
            _timer -= Time.deltaTime;
            rb.linearVelocityX = 0;
            if (_timer <= 0) Release();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ground"))
            {
                GameManager.LevelManager.ShakeScreen();
                _isSpiked = true;
            }
            if (collision.gameObject.CompareTag("Player"))
                collision.gameObject.GetComponent<PlayerController>().TakeDamage();
        }

        private void Release()
        {
            _isSpiked = false;
            __objectPool.Release(this);
            _timer = _spikeTime = Random.Range(3f, 7f); 
        }
    }
}
