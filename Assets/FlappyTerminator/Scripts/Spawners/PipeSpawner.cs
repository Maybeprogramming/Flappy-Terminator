using System.Collections;
using UnityEngine;

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

        pipe.Released += Released;
    }

    private void Released(Pipe pipe)
    {
        pipe.transform.position = Position;
        pipe.Released -= Released;
        Pool.Release(pipe);
    }
}
