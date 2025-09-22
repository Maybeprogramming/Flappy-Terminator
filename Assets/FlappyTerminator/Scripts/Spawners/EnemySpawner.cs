using System.Collections;
using UnityEngine;

public class EnemySpawner : PoolEntities<Enemy>
{
    [Header("Спавнер врагов")]
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private LaserSpawner _laserSpawner;
    [SerializeField] private float _delaySeconds;
    [SerializeField] private int _maxEnemiesCount;
    [SerializeField] private int _lowerPointY;
    [SerializeField] private int _upperPointY;
    [SerializeField] private float _xOffset;

    private WaitForSeconds _wait;

    public Vector3 Position => transform.position;

    private void Start()
    {
        _wait = new WaitForSeconds(_delaySeconds);
    }

    private void Spawn()
    {
        var enemy = Pool.Get();
        Debug.Log($"SPAWN {Pool.CountActive} | {_maxEnemiesCount}");
        InitEnemyPosition(enemy);
        enemy.Init(_cameraPosition, _laserSpawner);

        enemy.Dead += OnReleased;
    }

    private void InitEnemyPosition(Enemy enemy)
    {
        var newEnemyPosition = new Vector3(_cameraPosition.transform.position.x + _xOffset, 0f, _cameraPosition.transform.position.y);
        newEnemyPosition.y = _cameraPosition.position.y + Random.Range(_lowerPointY, _upperPointY);
        enemy.transform.position = newEnemyPosition;
    }

    private void OnReleased(Enemy enemy)
    {
        enemy.transform.position = Position;
        enemy.Dead -= OnReleased;
        Pool.Release(enemy);
    }

    private IEnumerator EnemySpawning()
    {
        while (enabled)
        {
            if (Pool.CountActive < _maxEnemiesCount)
            {
                Debug.Log($"{Pool.CountActive} | {_maxEnemiesCount}");
                Spawn();
            }

            yield return _wait;
        }
    }

    internal void StartSpawning()
    {
        StartCoroutine(EnemySpawning());
    }

    internal void Reset()
    {
        Pool.Dispose();
    }
}