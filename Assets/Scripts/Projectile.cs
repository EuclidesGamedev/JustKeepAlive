using UnityEngine;
using Utils;

public class Projectile : PooledObject
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
        }
        __objectPool.Release(this);
    }
}
