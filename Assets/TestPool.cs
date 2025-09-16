using System.Collections;
using UnityEngine;

public class TestSpawner : ObjectPool<Enemy>
{
    [SerializeField] private Transform _mainCamera;

    private void Start()
    {
        StartCoroutine(EnemySpawning());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Spawn();
        }
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
            yield return new WaitForSeconds(3);
        }
    }
}