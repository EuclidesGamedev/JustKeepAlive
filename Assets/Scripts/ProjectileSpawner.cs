using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectile;
    private float _spawnDelay = .4f;
    private float _timer = 0;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnDelay)
        {
            Instantiate(_projectile,
                new Vector3(Random.Range(-8.25f, 8.25f), 11f, 0), 
            Quaternion.identity);
            _timer = 0;
        }
    }
}
