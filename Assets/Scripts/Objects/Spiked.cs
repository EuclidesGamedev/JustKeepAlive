using Player;
using UnityEngine;
using Utils;

namespace Objects
{
    public class Spiked : PooledObject
    {
        private bool _isSpiked = false;
        private float _spikeTime;
        private float _timer;

        private void Start()
        {
            _timer = _spikeTime = Random.Range(3f, 7f);
        }
        
        private void Update()
        {
            if (!_isSpiked) return;
            
            _timer -= Time.deltaTime;
            if (_timer <= 0) __objectPool.Release(this);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Ground"))
                _isSpiked = true;
            if (collision.gameObject.CompareTag("Player"))
                collision.gameObject.GetComponent<PlayerController>().TakeDamage();
        }
    }
}
