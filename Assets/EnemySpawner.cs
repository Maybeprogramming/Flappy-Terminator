using System.Collections;
using UnityEngine;

public class EnemySpawner : ObjectPool<Enemy>
{
    [Header("Спавнер врагов:")]
    [SerializeField] private Transform _mainCamera;
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
        var enemy = GetObject();
        enemy.Init(this, _mainCamera);
        enemy.gameObject.SetActive(true);
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