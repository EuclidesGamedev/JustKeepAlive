using Game.Managers;
using Player;
using UnityEngine;
using Utils;

namespace Objects
{
    public class Disabler : PooledObject
    {
        private float _deactivationTime;

        private void Awake()
        {
            _deactivationTime = Random.Range(2, 8);
        }
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Platform platform))
            {
                GameManager.LevelManager.ShakeScreen();
                platform.Deactivate(_deactivationTime);
                __objectPool.Release(this);
            }
            
            if (collision.CompareTag("Player"))
                collision.gameObject.GetComponent<PlayerController>().TakeDamage();
        }
    }
}
