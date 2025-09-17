using System.Collections;
using System.Linq;
using UnityEngine;

public class EnemySpawner : ObjectPool<Enemy>
{
    [Header("Enemy Spawner:")]
    [SerializeField] private Transform _cameraPosition;
    [SerializeField] private float _delaySeconds;
    [SerializeField] private int _maxEnemiesCount;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_delaySeconds);
        StartCoroutine(EnemySpawning());
    }

    private void Spawn()
    {
        var enemy = GetObject();
        var enemyPosition = enemy.transform.position;
        enemyPosition.y = _cameraPosition.position.y + Random.Range(-2, 2);
        enemy.transform.position = enemyPosition;
        enemy.Init(this, _cameraPosition);
        enemy.gameObject.SetActive(true);
    }

    private IEnumerator EnemySpawning()
    {
        while (enabled)
        {
            if (ActiveCount < _maxEnemiesCount)
            {
                Spawn();
                Debug.Log($"В пуле: [" + Count + "] Активных: [" + ActiveCount + "]");
            }

            yield return _wait;
        }
    }
}