using Player;
using UnityEngine;
using Utils;

namespace Objects
{
    public class Water : PooledObject
    {
        private void Update()
        {
            if (transform.position.y < -5.25)
                __objectPool.Release(this);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player")) 
                collision.gameObject.GetComponent<PlayerController>().TakeDamage();
        }
    }
}
