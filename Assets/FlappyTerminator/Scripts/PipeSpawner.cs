using System.Collections;
using UnityEngine;

public class PipeSpawner : ObjectPool<Pipe>
{
    [Header("Pipe Spawner:")]
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

        var pipe = GetObject();

        pipe.gameObject.SetActive(true);
        pipe.transform.position = spawnPoint;
    }
}
