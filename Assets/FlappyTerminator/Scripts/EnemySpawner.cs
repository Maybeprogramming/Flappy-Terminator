using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : PoolEntities<Enemy>
{
    [Header("Спавнер врагов")]
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private LaserSpawner _laserSpawner;
    [SerializeField] private float _delaySeconds;
    [SerializeField] private int _maxEnemiesCount;
    [SerializeField] private int _lowerPointY;
    [SerializeField] private int _upperPointY;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_delaySeconds);
        StartCoroutine(EnemySpawning());
    }

    private protected override void PoolInit()
    {
        Pool = new ObjectPool<Enemy>(() => Create(),
                            (enemy) => PutEntity(enemy),
                            (enemy) => enemy.gameObject.SetActive(false),
                            (enemy) => Destroy(enemy),
                            true,
                            PoolDefaultCapacity,
                            PoolMaxCapacity);
    }

    private void Spawn()
    {
        var enemy = Pool.Get();
        InitEnemyPosition(enemy);
        enemy.Init(_cameraPosition, _laserSpawner);

        enemy.Dead += OnDead;
    }

    private void InitEnemyPosition(Enemy enemy)
    {
        var newEnemyPosition = new Vector3(_cameraPosition.transform.position.x, 0f, _cameraPosition.transform.position.y);
        newEnemyPosition.y = _cameraPosition.position.y + Random.Range(_lowerPointY, _upperPointY);
        enemy.transform.position = newEnemyPosition;
    }

    private void OnDead(Enemy enemy)
    {
        enemy.Dead -= OnDead;
        Pool.Release(enemy);
    }

    private IEnumerator EnemySpawning()
    {
        while (enabled)
        {
            if (Pool.CountActive < _maxEnemiesCount)
            {
                Spawn();
            }

            yield return _wait;
        }
    }
}