using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectPool<Enemy>
{
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private ObjectPool<Enemy> _pool;
    [SerializeField] private int _maxEnemyCount = 3;
    [SerializeField] private float _delaySpawnSeconds;

    private WaitForSeconds _delaySpawn;

    private void Awake()
    {
        _delaySpawn = new WaitForSeconds(_delaySpawnSeconds);
    }

    private void Start()
    {
        StartCoroutine(EnemySpawning());
    }

    private void Spawn()
    {
        var enemy = _pool.GetObject();
        enemy.gameObject.SetActive(true);
        enemy.Init(this, _mainCamera);
    }

    private IEnumerator EnemySpawning()
    {
        while (enabled)
        {
            Spawn();
            yield return _delaySpawn;
        }
    }
}