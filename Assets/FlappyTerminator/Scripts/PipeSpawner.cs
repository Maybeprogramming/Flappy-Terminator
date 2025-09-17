using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class PipeSpawner : PoolEntities<Pipe>
{
    [Header("Спавнер препятствий")]
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    private void Start()
    {
        StartCoroutine(GeneratePipes());
    }

    private protected override void PoolInit()
    {
        Pool = new ObjectPool<Pipe>(() => Create(),
                            (pipe) => PutEntity(pipe),
                            (pipe) => pipe.gameObject.SetActive(false),
                            (pipe) => Destroy(pipe),
                            true,
                            PoolDefaultCapacity,
                            PoolMaxCapacity);
    }

    private IEnumerator GeneratePipes()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled) 
        {
            Spawn();
            yield return wait;
        }
    }

    private void Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.position.z);

        var pipe = Pool.Get();
        pipe.transform.position = spawnPoint;

        pipe.Released += OnReleased;
    }

    private void OnReleased(Pipe pipe)
    {
        pipe.Released -= OnReleased;
        Pool.Release(pipe);
    }
}
